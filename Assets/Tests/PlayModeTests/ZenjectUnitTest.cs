using Zenject;
using NUnit.Framework;
using UnityTest.Models;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Tests.PlayModeTests
{
    [TestFixture]
    public class ZenjectUnitTest : ZenjectUnitTestFixture
    {
        private ZenjectSample _target = new ZenjectSample();

        [SetUp]
        public void CommonInstall()
        {
            //Container.Bind<ISword>()
            //    .To<SwordMock>()
            Container.BindInterfacesTo<SwordMock>()
                .AsTransient()
                .WithArguments("試し打ちの棍棒");

            Container.Bind<Player>()
                .AsTransient();

            // Injectされたいインスタンスを渡す
            Container.Inject(_target);
        }

        [Test]
        public void InjectTypeTest()
        {
            Assert.That(_target.Player.Sword, Is.InstanceOf<SwordMock>());
        }

        [Test]
        public void InjectValueTest()
        {
            Assert.That(_target.Player.Sword.Name, Is.EqualTo("試し打ちの棍棒"));
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            yield return null;
            // コンテナから直接取り出す場合
            var target = Container.Resolve<ISword>();
            Assert.That(target.Name, Is.EqualTo("試し打ちの棍棒"));
            yield return null;
        }
    }

    public class SwordMock : ISword, IInitializable
    {
        private string _name;
        public string Name => _name;
        public SwordMock(string name)
        {
            this._name = name;
        }

        public void Initialize()
        {
            Debug.Log("Initialize called.");
        }
    }
}