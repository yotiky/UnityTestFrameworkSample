using Zenject;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityTest.Models;
using System.Collections;
using Moq;
using System;
using UnityEngine;

namespace Tests.EditModeTests
{
    public interface IShield
    {
        string Name { get; }

        uint DefencePower { get; }

        void AddEffect(int value);

        uint CalcDefencePower();
    }
    [TestFixture]
    public class MoqUnitTest
    {
        [Test]
        public void MockObjectからのOutputの確認()
        {
            var mock = new Mock<IShield>();
            
            // プロパティのGet
            mock.Setup(x => x.Name).Returns("Name");
            // メソッドの戻り値
            mock.Setup(x => x.CalcDefencePower()).Returns(100);

            IShield shield = mock.Object;

            Assert.That(shield.Name, Is.EqualTo("Name"));
            Assert.That(shield.CalcDefencePower(), Is.EqualTo(100));
        }

        [Test]
        public void MockObjectへのInputの確認()
        {
            var mock = new Mock<IShield>();

            mock.Object.AddEffect(-10);

            mock.Verify(x => x.AddEffect(-10), Times.Once);
        }

        [Test]
        public void Mockのコールバック()
        {
            LogAssert.Expect(LogType.Log, "AddEffect called.");

            var mock = new Mock<IShield>();
            mock.Setup(x => x.AddEffect(It.IsAny<int>()))
                .Callback<int>(x => Debug.Log($"AddEffect called."));

            mock.Object.AddEffect(0);

            mock.Verify(x => x.AddEffect(It.IsAny<int>()), Times.AtLeastOnce);
        }
    }
}