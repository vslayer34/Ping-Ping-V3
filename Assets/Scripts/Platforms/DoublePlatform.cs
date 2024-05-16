using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlatform : MonoBehaviour
{
    [field: SerializeField, Header("Child Platforms"), Tooltip("Reference to the left platform")]
    public GameObject LeftPlatform { get; private set; }

    [field: SerializeField, Tooltip("Reference to the right platform")]
    public GameObject RightPlatform { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    private void OnDisable()
    {
        // set the disabled platform to active again
        LeftPlatform.SetActive(true);
        RightPlatform.SetActive(true);
    }
}
