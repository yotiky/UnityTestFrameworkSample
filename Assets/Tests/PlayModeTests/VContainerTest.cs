using NUnit.Framework;
using UnityTest.Models;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Tests.PlayModeTests
{
    [TestFixture]
    public class VContainerTest
    {
        private VContainerSample _target = new VContainerSample();

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
            _container.Inject(_target);
        }

        [Test]
        public void InjectTypeTest()
        {
            Assert.That(_target.Player.Sword, Is.InstanceOf<SwordMock>());
        }

        [Test]
        public void InjectValueTest()
        {
            Assert.That(_target.Player.Sword.Name, Is.EqualTo("本打ちの棍棒"));
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            yield return null;
            // コンテナから直接取り出す場合
            var target = _container.Resolve<ISword>();
            Assert.That(target.Name, Is.EqualTo("本打ちの棍棒"));
            yield return null;
        }
    }
}