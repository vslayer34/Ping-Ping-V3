using System.Collections;
using System.Collections.Generic;
using PingPing.Scripts.ScriptableObjectsBase;
using UnityEngine;

namespace PingPing.Scripts.Platforms
{
    public class DoublePlatform : MonoBehaviour
    {
        [SerializeField, Tooltip("Reference to the level configs")]
        private SO_GameResources _levelConfigs;



        [field: SerializeField, Space(5), Header("Child Platforms"), Tooltip("Reference to the left platform")]
        public GameObject LeftPlatform { get; private set; }

        [field: SerializeField, Tooltip("Reference to the right platform")]
        public GameObject RightPlatform { get; private set; }



        // Game Loop Methods---------------------------------------------------------------------------

        private void OnDisable()
        {
            // set the disabled platform to active again before adding it to the pool again
            LeftPlatform.SetActive(true);
            RightPlatform.SetActive(true);

            _levelConfigs.PlatformPool.Add(gameObject);
        }
    }
}
