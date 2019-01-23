using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class MovementSettings : ScriptableObject
{
    [Header("General Settings")]
    public int ExampleGeneral = 0;

    [Header("Jobs Settings")]
    public int Example = 0;

    [Header("Debug")]
    public bool ExampleDebug = false;

    public static MovementSettings LoadFromResources()
    {
        return Resources.Load<MovementSettings>("DefaultMovementSettings");
    }
}
