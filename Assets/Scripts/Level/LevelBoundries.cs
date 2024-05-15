using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace PingPing.Scripts.Level
{
    public class LevelBoundries : MonoBehaviour
    {
        [field: SerializeField, Header("Child Game objects"), Tooltip("Reference to the edge collider of the top bounds")]
        public EdgeCollider2D TopBounds { get; private set; }

        [field: SerializeField, Tooltip("Reference to the edge collider of the buttom bounds")]
        public EdgeCollider2D ButtomBounds { get; private set; }


        [SerializeField, Header("Level Camera"), Tooltip("Reference to the level camera to get its orthographic size")]
        private CinemachineVirtualCamera _levelMainCamera;

        private float _cameraSize;

        
        
        // Game Loop Methods-----------------------------------------------------------------------
        void Start()
        {
            _cameraSize = _levelMainCamera.m_Lens.OrthographicSize;
            SetupLevelBounds();
        }

        // Memeber methods-------------------------------------------------------------------------
        /// <summary>
        /// Set the level bounds dynamically according to the device size
        /// </summary>
        private void SetupLevelBounds()
        {
            TopBounds.offset = new Vector2(0.0f, _cameraSize / 2);
            ButtomBounds.offset = new Vector2(0.0f, -1 * _cameraSize / 2);
        }
    }
}