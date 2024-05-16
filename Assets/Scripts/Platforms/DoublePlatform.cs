using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlatform : MonoBehaviour
{
    [field: SerializeField, Header("Child Platforms"), Tooltip("Reference to the left platform")]
    public GameObject LeftPlatform { get; private set; }

    [field: SerializeField, Tooltip("Reference to the right platform")]
    public GameObject RightPlatform { get; private set; }
}
