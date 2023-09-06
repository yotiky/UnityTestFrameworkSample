using UnityEngine;
using Zenject;

namespace UnityTest.Models
{
    public interface ISword
    {
        string Name { get; }
    }

    public partial class Sword : ISword, IInitializable
    {
        private string _material;
        private string _author;

        public string Name => $"{_material}の剣";

        public Sword(string material, string author)
        {
            _material = material;
            _author = author;

            Debug.Log($"{Name} made by {_author}");

            // エディタやテストからは呼べるが、通常はビルドする時にエラーになる
            //InitializeTest();
        }

        public void Initialize()
        {
            Debug.Log("Initialize called.");
        }
    }
}