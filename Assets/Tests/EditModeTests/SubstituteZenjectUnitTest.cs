using Zenject;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using System;
using UnityEngine;
using NSubstitute;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class SubstituteZenjectUnitTest : ZenjectUnitTestFixture
    {
        [Test]
        public void SimpleTest()
        {
            var mock = Substitute.For<ISystemClock>();
            mock.Now.Returns(new DateTime(2023, 1, 1));

            Container.BindInstance(mock)
                .AsTransient();

            Container.Bind<Ticket>()
                .AsTransient()
                .WithArguments(10u);

            var target = Container.Resolve<Ticket>();
            Assert.That(target.Issue, Is.EqualTo(new DateTime(2023, 1, 1).AddDays(10)));
        }
    }
}