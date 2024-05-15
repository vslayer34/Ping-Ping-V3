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

        public void LaunchBall(float launchForce = 10.0f)
        {
            Vector2 launchVector = new Vector2(1, Random.Range(-1.0f, 1.0f));
            _rb.AddForce(launchVector * launchForce, ForceMode2D.Impulse);
        }
    }
}
