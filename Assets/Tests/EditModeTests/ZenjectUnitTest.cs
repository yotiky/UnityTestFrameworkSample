using Zenject;
using NUnit.Framework;
using UnityTest.Models;
using System.Collections;
using UnityEngine.TestTools;
using UnityEngine;
using System.ComponentModel;

namespace Tests.EditModeTests
{
    [TestFixture]
    public class ZenjectUnitTest : ZenjectUnitTestFixture
    {
        [Inject]
        private ISword _target;

        [SetUp]
        public void CommonInstall()
        {
            Container.BindInterfacesTo<SwordMock>()
                .AsTransient()
                .WithArguments("試し打ちの棍棒");

            Container.Bind<Player>()
                .AsTransient();

            Container.Bind<ZenjectSample>()
                .FromNewComponentOnNewGameObject()
                .AsTransient();

            // Injectされたいインスタンスを渡すこともできる
            Container.Inject(this);
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
            var target = Container.Resolve<ISword>();
            Assert.That(target.Name, Is.EqualTo("試し打ちの棍棒"));
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            yield return null;
            var target = Container.Resolve<ZenjectSample>();
            Assert.That(target.Player.Sword.Name, Is.EqualTo("試し打ちの棍棒"));
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
            // ZenjectUnitTestFixtureでは呼ばれない
            Debug.Log("Initialize called.");
        }
    }
}