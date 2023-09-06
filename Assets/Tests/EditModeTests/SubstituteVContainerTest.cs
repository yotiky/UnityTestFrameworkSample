using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using System;
using UnityEngine;
using VContainer;
using NSubstitute;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class SubstituteVContainerTest
    {
        [Test]
        public void SimpleTest()
        {
            var mock = Substitute.For<ISystemClock>();
            mock.Now.Returns(new DateTime(2023, 1, 1));

            var builder = new ContainerBuilder();

            builder.RegisterInstance(mock);

            builder.Register<Ticket>(Lifetime.Transient)
                .WithParameter(typeof(uint), 10u);

            var container = builder.Build();

            var target = container.Resolve<Ticket>();
            Assert.That(target.Issue, Is.EqualTo(new DateTime(2023, 1, 1).AddDays(10)));
        }
    }
}