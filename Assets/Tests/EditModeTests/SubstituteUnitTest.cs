using Zenject;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using Moq;
using System;
using UnityEngine;
using NSubstitute;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class SubstituteUnitTest
    {
        [Test]
        public void MockObjectからのOutputの確認()
        {
            var mock = Substitute.For<IShield>();
            
            // プロパティのGet
            mock.Name.Returns("Name");
            // メソッドの戻り値
            mock.CalcDefencePower().Returns(100u);

            Assert.That(mock.Name, Is.EqualTo("Name"));
            Assert.That(mock.CalcDefencePower(), Is.EqualTo(100));
        }

        [Test]
        public void MockObjectへのInputの確認()
        {
            var mock = Substitute.For<IShield>();

            mock.AddEffect(-10);

            mock.ReceivedWithAnyArgs(1).AddEffect(-10);
        }

        [Test]
        public void Mockのコールバック()
        {
            LogAssert.Expect(LogType.Log, "AddEffect called.");

            var mock = Substitute.For<IShield>();

            mock.When(x => x.AddEffect(Arg.Any<int>()))
                .Do(_ => Debug.Log($"AddEffect called."));

            mock.AddEffect(0);

            mock.ReceivedWithAnyArgs(1).AddEffect(Arg.Any<int>());
        }
    }
}