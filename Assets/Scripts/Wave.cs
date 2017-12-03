using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Wave
    {
        [Serializable]
        public class WaveSection
        {
            public GameObject enemyType;
            public int count;
            public float spawnSpeed;
        }
        [SerializeField]
        public WaveSection[] parts;
    }
}
