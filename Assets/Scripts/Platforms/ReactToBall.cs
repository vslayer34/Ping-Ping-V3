using System.Collections;
using System.Collections.Generic;
using PingPing.Scripts.Ball;
using UnityEngine;

namespace PingPing.Scripts.Platforms
{
    public class ReactToBall : MonoBehaviour
    {
        private BoxCollider2D _collider;



        // Game Loop Methods-----------------------------------------------------------------------

        private void Start()
        {
            _collider = GetComponent<BoxCollider2D>();
        }

        // Member Methods--------------------------------------------------------------------------

        private IEnumerator DisablePlatform()
        {
            yield return new WaitForSeconds(0.5f);

            gameObject.SetActive(false);
        }

        // Built-in Methods------------------------------------------------------------------------

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.TryGetComponent(out BallBehaviour ball))
            {
                Debug.Log($"The {ball.name} hit me");
                StartCoroutine(DisablePlatform());
            }
        }
    }
}
