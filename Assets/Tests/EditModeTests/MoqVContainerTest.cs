using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using Moq;
using System;
using UnityEngine;
using VContainer;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class MoqVContainerTest
    {
        [Test]
        public void SimpleTest()
        {
            var mock = new Mock<ISystemClock>();
            mock.Setup(x => x.Now).Returns(new DateTime(2023, 1, 1));

            var builder = new ContainerBuilder();

            builder.RegisterInstance(mock.Object);

            builder.Register<Ticket>(Lifetime.Transient)
                .WithParameter(typeof(uint), 10u);

            var container = builder.Build();

            var target = container.Resolve<Ticket>();
            Assert.That(target.Issue, Is.EqualTo(new DateTime(2023, 1, 1).AddDays(10)));
        }
    }
}