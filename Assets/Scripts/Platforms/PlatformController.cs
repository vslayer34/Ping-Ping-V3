using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace PingPing.Scripts.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        // Temporary removed as I may not need it
        /*
        [SerializeField, Tooltip("horizantal speed")]
        private float _horizontalSpeed = 1.0f;

        [SerializeField, Tooltip("the platform vertical speed")]
        private float _verticalSpeed;
        */

        [SerializeField, Tooltip("speed of the platform")]
        private float _speed;

        private BoxCollider2D _collider;

        private bool _isDragged;
        private int _fingerIndex;
        private Vector2 _movementDirection = Vector2.left;



        // Game Loop Methods-----------------------------------------------------------------------
        
        private void OnEnable()
        {
            EnhancedTouchSupport.Enable();
            _collider = GetComponent<BoxCollider2D>();

            Touch.onFingerDown += HandleTouch;
            Touch.onFingerMove += HandleDragingMotion;
            Touch.onFingerUp += HandleReleaseMotion;
        }

        private void OnDisable()
        {
            EnhancedTouchSupport.Disable();

            Touch.onFingerDown -= HandleTouch;
            Touch.onFingerMove -= HandleDragingMotion;
            Touch.onFingerUp -= HandleReleaseMotion;
        }

        private void Update()
        {
            MoveHorizontaly();
            DetectTouch();
        }

        // Member Methods--------------------------------------------------------------------------

        /// <summary>
        /// Move the platform to the left of the screen
        /// </summary>
        private void MoveHorizontaly()
        {
            transform.Translate(_speed * Time.deltaTime * _movementDirection);
            // transform.Translate(_movementDirection * _horizontalSpeed * Time.deltaTime);
        }

        /// <summary>
        /// Take the touch position and calculate the delta to the platform position
        /// and according to the delta move upwards or downwards
        /// </summary>
        /// <param name="direction"></param>
        private void MoveVertically(Vector2 direction)
        {
            Debug.Log(direction.y - transform.position.y);

            _movementDirection = Vector2.left + (direction.y - transform.position.y > 0 ? Vector2.up : Vector2.down);
            _movementDirection = _movementDirection.normalized;

            transform.Translate(_speed * Time.deltaTime * _movementDirection);
        }

        private void DetectTouch()
        {
            // Debug.Log(Touch.fingers
        }

        // Signal Methods--------------------------------------------------------------------------

        /// <summary>
        /// Get the touch position and index and set dragging status
        /// </summary>
        private void HandleTouch(Finger finger)
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
            worldPosition.z = 0.0f;

            if (_collider == Physics2D.OverlapPoint(worldPosition))
            {
                Debug.Log($"Over lapped!!");
                _isDragged = true;
                _fingerIndex = finger.index;
            }
        }

        /// <summary>
        /// Update the touch position while its moving along the screen
        /// </summary>
        private void HandleDragingMotion(Finger finger)
        {
            if (!_isDragged)
            {
                return;
            }

            var worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
            worldPosition.z = 0.0f;

            MoveVertically(worldPosition);
        }

         /// <summary>
         /// Remove dragging status and default the platform direction
         /// </summary>
         private void HandleReleaseMotion(Finger finger)
        {
            // if the touch was dragging the platform reset all parameters
            if (_isDragged)
            {
                _isDragged = false;
                _movementDirection = Vector2.left;
            }
        }        
    }
}
