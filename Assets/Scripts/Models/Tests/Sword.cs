#if UNITY_INCLUDE_TESTS
using UnityEngine;

namespace UnityTest.Models
{
    public partial class Sword
    {
        public string Material => _material;
        public string Author => _author;

        private void InitializeTest()
        {
            Debug.Log("patial class for testing.");
        }
    }
}
#endif