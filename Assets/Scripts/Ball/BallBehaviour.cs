using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PingPing.Scripts.Ball
{
    public class BallBehaviour : MonoBehaviour
    {
        private Rigidbody2D _rb;



        // Game Loop Methods-----------------------------------------------------------------------
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Member Methods--------------------------------------------------------------------------

        public void LaunchBall()
        {
            _rb.AddForce(Vector2.right * 100, ForceMode2D.Impulse);
        }
    }
}
