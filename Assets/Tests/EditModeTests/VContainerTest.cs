using NUnit.Framework;
using UnityTest.Models;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using System.ComponentModel;
using VContainer;
using VContainer.Unity;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class VContainerTest
    {
        [Inject]
        private ISword _target;

        private IObjectResolver _container;

        [SetUp]
        public void CommonInstall()
        {
            var builder = new ContainerBuilder();

            builder.Register<SwordMock>(Lifetime.Transient)
                .WithParameter("本打ちの棍棒")
                .AsImplementedInterfaces();

            builder.Register<Player>(Lifetime.Transient);

            builder.RegisterComponentOnNewGameObject<VContainerSample>(Lifetime.Transient);

            _container = builder.Build();

            // Injectされたいインスタンスを渡すこともできる
            _container.Inject(this);
        }

        [Test]
        public void InjectTypeTest()
        {
            Assert.That(_target, Is.InstanceOf<SwordMock>());
        }

        [Test]
        public void InjectValueTest()
        {
            // コンテナから直接取り出す場合
            var target = _container.Resolve<ISword>();
            Assert.That(target.Name, Is.EqualTo("本打ちの棍棒"));
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            yield return null;
            var target = _container.Resolve<VContainerSample>();
            Assert.That(target.Player.Sword.Name, Is.EqualTo("本打ちの棍棒"));
            yield return null;
        }
    }
}