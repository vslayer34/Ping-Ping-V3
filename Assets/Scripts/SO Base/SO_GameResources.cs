using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPing.Scripts.ScriptableObjectsBase
{
    [System.Serializable]
    public struct PlatformSpawnIntervals
    {
        public float minTime;
        public float maxTime;
    }

    [CreateAssetMenu(fileName = "new level configs", menuName = "Game/Configs")]
    public class SO_GameResources : ScriptableObject
    {
        [field: SerializeField, Header("Game time settings"), Tooltip("Reference to the spawn rate time")]
        public PlatformSpawnIntervals SpawnRate { get; private set; } = new PlatformSpawnIntervals();


        [field: SerializeField, Space(5), Tooltip("When to start the game")]
        public float StartTimer { get; private set; }


        [field: SerializeField, Header("Platform Pool"), Tooltip("Pool size")]
        public int PlatformsPoolSize { get; private set; }
        
        [field: SerializeField, Tooltip("Double platforms pool")]
        public List<GameObject> PlatformPool { get; private set; }

        [field: SerializeField, Tooltip("Reference to the platform prefab")]
        public GameObject DoublePlatformPrefab { get; private set; }



        // Pool Methods----------------------------------------------------------------------------

        public void FillPlatformPool()
        {
            Debug.Log("Called");
            GameObject newPlatform;
            PlatformPool = new List<GameObject>(PlatformsPoolSize);

            for (int i = 0; i < PlatformsPoolSize; i++)
            {
                newPlatform = Instantiate(DoublePlatformPrefab, DoublePlatformPrefab.transform.position, Quaternion.identity);
                newPlatform.SetActive(false);
                PlatformPool.Add(newPlatform);

                Debug.Log("new platform added");
            }
        }
    }
}
