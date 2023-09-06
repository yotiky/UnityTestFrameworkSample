using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Moq;
using NSubstitute;
using NUnit.Framework;
using Tests.EditModeTests;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.EditModeTests
{
    public class UniRxTest
    {
        [Test]
        public void UniRxMoqTest()
        {
            var reactiveDummy = new ReactiveProperty<int>();
            var subjectDummy = new Subject<int>();

            var mock = new Mock<IUniRxSample>();
            mock.Setup(x => x.OnSubject).Returns(subjectDummy);
            mock.Setup(x => x.OnReactiveProperty).Returns(reactiveDummy);

            mock.Object.OnSubject.Subscribe(x => Assert.That(x, Is.EqualTo(1)));

            subjectDummy.OnNext(1);

            var results = new List<int>();
            mock.Object.OnReactiveProperty.Subscribe(x => results.Add(x));

            reactiveDummy.Value = 2;
            
            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(0));
            Assert.That(results[1], Is.EqualTo(2));
        }

        [Test]
        public void UniRxNSubstituteTest()
        {
            var reactiveDummy = new ReactiveProperty<int>();
            var subjectDummy = new Subject<int>();

            var mock = Substitute.For<IUniRxSample>();
            mock.OnSubject.Returns(subjectDummy);
            mock.OnReactiveProperty.Returns(reactiveDummy);

            mock.OnSubject.Subscribe(x => Assert.That(x, Is.EqualTo(1)));

            subjectDummy.OnNext(1);

            var results = new List<int>();
            mock.OnReactiveProperty.Subscribe(x => results.Add(x));

            reactiveDummy.Value = 2;

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0], Is.EqualTo(0));
            Assert.That(results[1], Is.EqualTo(2));
        }
    }
}