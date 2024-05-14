using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

namespace PingPing.Scripts.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        [SerializeField, Tooltip("horizantal speed")]
        private float _horizontalSpeed = 1.0f;

        [SerializeField, Tooltip("the platform vertical speed")]
        private float _verticalSpeed;

        private BoxCollider2D _collider;

        private bool _isDragged;
        private int _fingerIndex;
        private Vector2 _movementDirection;



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

        private void MoveHorizontaly()
        {
            transform.Translate(Vector2.left * _horizontalSpeed * Time.deltaTime);
        }

        private void MoveVertically(Vector2 direction)
        {
            var moveVector = Vector2.left + direction;
            moveVector = moveVector.normalized;

            transform.Translate(moveVector * _verticalSpeed * Time.deltaTime);
        }

        private void DetectTouch()
        {
            // Debug.Log(Touch.fingers
        }

        // Signal Methods--------------------------------------------------------------------------

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

        private void HandleDragingMotion(Finger finger)
        {
            if (!_isDragged)
            {
                return;
            }

            var worldPosition = Camera.main.ScreenToWorldPoint(finger.screenPosition);
            worldPosition.z = 0.0f;

            if (finger.currentTouch.delta.y > 0)
            {
                _movementDirection = Vector2.up;
                MoveVertically(_movementDirection);
            }
            else if (finger.currentTouch.delta.y < 0)
            {
                _movementDirection = Vector2.down;
                MoveVertically(_movementDirection);
            }
        }

         private void HandleReleaseMotion(Finger finger)
        {
            
        }        
    }
}
