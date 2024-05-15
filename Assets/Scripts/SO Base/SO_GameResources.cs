using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPing.Scripts.ScriptableObjectsBase
{
    public struct PlatformSpawnIntervals
    {
        public float minTime;
        public float maxTime;
    }

    [CreateAssetMenu(fileName = "new level configs", menuName = "Game/Configs")]
    public class SO_GameResources : ScriptableObject
    {
        [field: SerializeField, Header("Game time settings"), Tooltip("Reference to the spawn rate time")]
        public PlatformSpawnIntervals SpawnRate { get; private set; }


        [field: SerializeField, Tooltip("When to start the game")]
        public float StartTimer { get; private set; }


        [field: SerializeField, Header("Platform Pool"), Tooltip("Pool size")]
        public int PlatformsPoolSize { get; private set; }
        
        [field: SerializeField, Tooltip("Double platforms pool")]
        public List<GameObject> PlatformPool { get; private set; }

    }
}
