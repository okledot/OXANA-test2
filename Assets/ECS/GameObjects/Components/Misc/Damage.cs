using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace GameObjects
{
    public struct Damage : IComponentData
    {
        public float Value;
    }
}