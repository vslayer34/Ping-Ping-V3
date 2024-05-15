using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPing.Scripts.Level
{
    public class PlatformSpawner : MonoBehaviour
    {
        [field: SerializeField, Tooltip("Reference to the spawn point")]
        public Transform SpawnPoint { get; private set; }


        [SerializeField, Tooltip("reference to the platform prefab")]
        private GameObject _doublePlatformPrefab;



        // Game Loop Methods-----------------------------------------------------------------------

        private void Start()
        {
            InvokeRepeating(nameof(SpawnNewPlatform), 3, 2);
        }

        // Member Methods--------------------------------------------------------------------------

        private void SpawnNewPlatform()
        {
            var newPlatform = Instantiate(_doublePlatformPrefab, SpawnPoint.position, Quaternion.identity);
        }
    }
}
