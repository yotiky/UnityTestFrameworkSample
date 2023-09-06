using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityTest.Models
{
    public class Player
    {
        private ISword _sword;
        public ISword Sword => _sword;

        public Player(ISword sword)
        {
            _sword = sword;
        }
    }
}