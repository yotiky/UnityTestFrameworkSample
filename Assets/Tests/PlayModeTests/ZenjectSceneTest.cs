using Zenject;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using UnityTest.Models;
using NUnit.Framework;
using System.ComponentModel;
using static UnityEngine.GraphicsBuffer;

namespace Tests.PlayModeTests
{
    public class ZenjectSceneTest : SceneTestFixture
    {
        [UnityTest]
        public IEnumerator TestScene()
        {
            StaticContext.Container
                .BindInterfacesTo<SwordMock>()
                .AsTransient()
                .WithArguments("妖刀村正");

            StaticContext.Container
                .Bind<Player>()
                .AsTransient();

            yield return LoadScene("ZenjectSample");

            var injected = SceneContainer.Resolve<ISword>();
            Assert.That(injected, Is.InstanceOf<SwordMock>());
            yield return null;

            var obj = GameObject.Find("GameObject");
            var target = obj.GetComponent<ZenjectSample>();
            Assert.That(target.Player.Sword, Is.InstanceOf<SwordMock>());
            Assert.That(target.Player.Sword.Name, Is.EqualTo("妖刀村正"));
        }
    }
}