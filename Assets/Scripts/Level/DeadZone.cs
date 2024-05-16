using System.Collections;
using System.Collections.Generic;
using PingPing.Scripts.Platforms;
using UnityEngine;

namespace PingPing.Scripts.Level
{
    public class DeadZone : MonoBehaviour
    {
        /// <summary>
        /// Disable the platform after hitting the dead zone
        /// </summary>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DoublePlatform doublePlatform))
            {
                doublePlatform.gameObject.SetActive(false);
            }
        }
    }
}
