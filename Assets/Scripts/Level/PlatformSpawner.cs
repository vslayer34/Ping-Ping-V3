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

        private void SpawnNewPlatform()
        {
            _newDoublePlatform = _levelConfigs.GetNewDoublePlatform();
            _newDoublePlatform.transform.position = SpawnPoint.position;
        }
    }
}
