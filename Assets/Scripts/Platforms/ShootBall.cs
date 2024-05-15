using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPing.Scripts.Platforms
{
    public class ShootBall : MonoBehaviour
    {
        [field: SerializeField, Tooltip("Reference to the ball holder area")]
        public Transform BallHolderArea { get; private set; }

        
    }
}
