﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Movement
{
    public struct Velocity : IComponentData
    {
        public float3 Value;
    }
}

