using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Rendering;

namespace Movement
{
    [Serializable]
    public struct Input : ISharedComponentData
    {
        public float Horizontal;
        public float Vertical;
    }

    public class InputComponent : SharedComponentDataWrapper<Input> { }
}


