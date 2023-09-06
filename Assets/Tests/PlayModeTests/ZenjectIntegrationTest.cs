using Zenject;
using System.Collections;
using UnityEngine.TestTools;
using NUnit.Framework;
using UnityTest.Models;

namespace Tests.PlayModeTests
{
    public class ZenjectIntegrationTest : ZenjectIntegrationTestFixture
    {
        [Inject]
        private ISword _target;

        private void CommonInstall()
        {
            PreInstall();

            Container.BindInterfacesTo<SwordMock>()
                .AsTransient()
                .WithArguments("ひのきの棒");

            Container.Bind<Player>()
                .AsTransient();

            Container.Bind<ZenjectSample>()
                .FromNewComponentOnNewGameObject()
                .AsTransient();

            PostInstall();
        }

        [Test]
        public void InjectTypeTest()
        {
            CommonInstall();
            Assert.That(_target, Is.InstanceOf<SwordMock>());
        }

        [Test]
        public void InjectValueTest()
        {
            CommonInstall();
            // コンテナから直接取り出す場合
            var target = Container.Resolve<ISword>();
            Assert.That(target.Name, Is.EqualTo("ひのきの棒"));
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            CommonInstall();
            yield return null;

            var target = Container.Resolve<ZenjectSample>();
            Assert.That(target.Player.Sword.Name, Is.EqualTo("ひのきの棒"));
            yield return null;
        }
    }
}