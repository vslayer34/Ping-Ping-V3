using System.Collections;
using System.Collections.Generic;
using PingPing.Scripts.Ball;
using UnityEngine;

namespace PingPing.Scripts.Platforms
{
    public class ShootBall : MonoBehaviour
    {
        [field: SerializeField, Tooltip("Reference to the ball holder area")]
        public Transform BallHolderArea { get; private set; }

        [field: SerializeField, Tooltip("Reference to the ball itself")]
        public BallBehaviour Ball { get; private set; }



        // Game Loop Methods-----------------------------------------------------------------------

        private void Start()
        {
            Invoke(nameof(StartGame), 2.0f);
        }

        // Member methods--------------------------------------------------------------------------

        private void StartGame()
        {
            BallHolderArea.parent = null;
            Ball.LaunchBall();
        }
    }
}
