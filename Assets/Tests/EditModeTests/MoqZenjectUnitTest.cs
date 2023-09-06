using Zenject;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using Moq;
using System;
using UnityEngine;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class MoqZenjectUnitTest : ZenjectUnitTestFixture
    {
        [Test]
        public void SimpleTest()
        {
            var mock = new Mock<ISystemClock>();
            mock.Setup(x => x.Now).Returns(new DateTime(2023, 1, 1));

            Container.BindInstance(mock.Object)
                .AsTransient();

            Container.Bind<Ticket>()
                .AsTransient()
                .WithArguments(10u);

            var target = Container.Resolve<Ticket>();
            Assert.That(target.Issue, Is.EqualTo(new DateTime(2023, 1, 1).AddDays(10)));
        }
    }
}