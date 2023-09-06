using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.EditModeTests
{
    public class SimpleEditModeTests
    {
        [Test]
        public void Test属性のTest()
        {
            Assert.That(1 < 10);
        }

        [UnityTest]
        public IEnumerator UnityTest属性のTest()
        {
            Assert.That(1, Is.LessThan(10));
            yield return null;
            Assert.That(2, Is.LessThan(10));
            // yield return nullしか使えないので失敗する
            yield return new WaitForSeconds(2f);
            Assert.That(3, Is.LessThan(10));
        }

        [UnityTest]
        public IEnumerator EnterPlayModeのTest()
        {
            yield return new EnterPlayMode();

            // PlayModeに入っても yield return nullしか使えないので失敗する
            yield return new WaitForSeconds(1);
            Assert.That(1 < 10);

            yield return new ExitPlayMode();
        }

        [Test]
        public async Task 非同期TaskのTest()
        {
            await Task.Delay(2000);
            Assert.That(true);
        }

        [Test]
        public async Task 非同期UniTaskのTest()
        {
            await UniTask.Delay(2000);
            await UniTask.DelayFrame(1000);
            Assert.That(true);
        }

        [UnityTest]
        public IEnumerator 古いUniTaskコルーチンを使ったTest()
            => UniTask.ToCoroutine(async () =>
            {
                await UniTask.Delay(2000);
                await UniTask.DelayFrame(1000);
                Assert.That(true);
            });
    }
}