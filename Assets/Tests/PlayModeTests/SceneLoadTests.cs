using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests.PlayModeTests
{
    public class SceneLoadTests
    {

        [UnityTest]
        public IEnumerator SceneをロードするTest()
        {
            var name = "SceneLoadTest";

            LogAssert.Expect(LogType.Log, $"Hello from {name}");

            SceneManager.LoadScene(name);

            yield return null;
        }
    }
}