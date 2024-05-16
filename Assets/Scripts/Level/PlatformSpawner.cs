using System.Collections;
using System.Collections.Generic;
using PingPing.Scripts.ScriptableObjectsBase;
using UnityEngine;

namespace PingPing.Scripts.Level
{
    public class PlatformSpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the level configs")]
        private SO_GameResources _levelConfigs;


        [field: SerializeField, Space(10), Tooltip("Reference to the spawn point")]
        public Transform SpawnPoint { get; private set; }


        [SerializeField, Tooltip("reference to the platform prefab")]
        private GameObject _doublePlatformPrefab;



        // Game Loop Methods-----------------------------------------------------------------------

        private void Start()
        {
            // InvokeRepeating(nameof(SpawnNewPlatform), 3, 2);

            _levelConfigs.FillPlatformPool();
        }

        // Member Methods--------------------------------------------------------------------------

        private void SpawnNewPlatform()
        {
            var newPlatform = Instantiate(_doublePlatformPrefab, SpawnPoint.position, Quaternion.identity);
        }
    }
}
