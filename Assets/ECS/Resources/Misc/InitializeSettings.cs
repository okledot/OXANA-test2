using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Rendering;
using Unity.Transforms;
using System;
using Physics;
using UnityEditor;
using UnityEditorInternal;

[System.Serializable]
[CreateAssetMenu (fileName = "DefaultInitializeSettings", menuName = "Initialize Settings")]
public class InitializeSettings : ScriptableObject
{
    [Header("General Settings")]
    [SerializeField] public bool spawnObjects = false;
    [SerializeField] public int enemyCount = 10;
    [SerializeField] public int itemsCount = 10;
    [SerializeField] public int levelLength = 8;
    [SerializeField] public int levelHeight = 5;
    
    [Header("Player Settings")]
    public PlayerSet playerStats;
    [Header("Enemy Settings")]
    public EnemySet enemyStats;
    [Header("Item Settings")]
    public ItemSet itemStats;
    [Header("Block Settings")]
    public BlockSet blockStats;
    [Header("Water Settings")]
    public WaterSet waterStats;

    [Serializable]
    public struct PlayerSet
    {
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public float3 aabbcollider;// = new float3 (0,0,0);
        public float rigidbody;// = 0.0f;
        public float3 velocity;// = new float3 (0,0,0);
        public float health;// = 0.0f;
        public float damage;// = 0.0f;
        public MeshInstanceRenderer render;
    }

    [Serializable]
    public class EnemySet
    {
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public float3 aabbcollider;
        public float rigibody;
        public float3 velocity;
        public float health;
        public float damage;
        public MeshInstanceRenderer render;
    }

    [Serializable]
    public class ItemSet
    {
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public float3 aabbcollider;
        public float rigidbody;
        public MeshInstanceRenderer render;
    }

    [Serializable]
    public class BlockSet
    {
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public float3 aabbcollider;
        public MeshInstanceRenderer render;
    }

    [Serializable]
    public class WaterSet
    {
        public Position position;
        public Rotation rotation;
        public Scale scale;
        public MeshInstanceRenderer render;
    }

    public static InitializeSettings LoadFromResources()
    {
        return Resources.Load<InitializeSettings>("DefaultInitializeSettings");
    }
}
