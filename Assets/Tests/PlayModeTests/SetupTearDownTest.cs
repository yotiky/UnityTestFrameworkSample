using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.PlayModeTests
{
    public class SetupTearDownTest
    {
        [OneTimeSetUp]
        public void OneTimeSetUp() => Debug.Log("OneTimeSetUp");

        [OneTimeTearDown]
        public void OneTimeTearDown() => Debug.Log("OneTimeTearDown");

        [SetUp]
        public void Setup() => Debug.Log("Setup");

        [TearDown]
        public void TearDown() => Debug.Log("TearDown");

        [UnitySetUp]
        public IEnumerator UnitySetUp()
        {
            Debug.Log("UnitySetUp");
            yield return null;
        }

        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            Debug.Log("UnityTearDown");
            yield return null;
        }

        [Test]
        public void TestCase1() => Debug.Log("TestCase1-Test");

        [UnityTest]
        public IEnumerator TestCase2()
        {
            Debug.Log("TestCase2-UnityTest");
            yield return null;
        }
    }
}