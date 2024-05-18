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

        private GameObject _newDoublePlatform;
        private Vector2 _randomSpawnPoint;



        // Game Loop Methods-----------------------------------------------------------------------

        private void Start()
        {
            InvokeRepeating(nameof(SpawnNewPlatform), 
                _levelConfigs.StartTimer, 
                Random.Range(_levelConfigs.SpawnRate.minTime, _levelConfigs.SpawnRate.maxTime)
            );

            _levelConfigs.FillPlatformPool();
        }

        // Member Methods--------------------------------------------------------------------------

        /// <summary>
        /// Get a new platform from the pool and set its spawning position
        /// </summary>
        private void SpawnNewPlatform()
        {
            _newDoublePlatform = _levelConfigs.GetNewDoublePlatform();

            _randomSpawnPoint = new Vector2(
                SpawnPoint.position.x, 
                Random.Range(_levelConfigs.YAxisSpawnInterval.minYPosition, _levelConfigs.YAxisSpawnInterval.maxYPosition)
            );

            _newDoublePlatform.transform.position = _randomSpawnPoint;
        }
    }
}
