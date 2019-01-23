using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;

public static class ObjectsEntityFactory
{
    #region "Архетип игрока"
    public static EntityArchetype CreatePlayerArchetype (EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            //Transform
            typeof(Position),
            typeof(Rotation),
            typeof(Scale),
            //Physics
            typeof(Physics.AABBCollider),
            typeof(Physics.RigidbodyComponent),
            //Movement
            typeof(Movement.Input),
            typeof(Movement.Velocity),
            //Game
            typeof(GameObjects.Health),
            typeof(GameObjects.Damage),
            //Render
            typeof(MeshInstanceRendererComponent)
            );
    }
    #endregion

    #region "Архетип противника"
    public static EntityArchetype CreateEnemyArchetype(EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            //Transform
            typeof(Position),
            typeof(Rotation),
            typeof(Scale),
            //Physics
            typeof(Physics.AABBCollider),
            typeof(Physics.RigidbodyComponent),
            //Movement
            typeof(Movement.Velocity),
            //Game
            typeof(GameObjects.Health),
            typeof(GameObjects.Damage)
            );
    }
    #endregion

    #region "Архетип предмета"
    public static EntityArchetype CreateItemArchetype(EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            //Transform
            typeof(Position),
            typeof(Rotation),
            typeof(Scale),
            //Physics
            typeof(Physics.AABBCollider),
            typeof(Physics.RigidbodyComponent)
            );
    }
    #endregion

    #region "Архетип блока"
    public static EntityArchetype CreateBlockArchetype(EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            //Transform
            typeof(Position),
            typeof(Rotation),
            typeof(Scale),
            //Physics
            typeof(Physics.AABBCollider)
            //typeof(PhysicsEngine.Collider)
            );
    }
    #endregion

    #region "Архетип воды"
    public static EntityArchetype CreateWaterArchetype(EntityManager entityManager)
    {
        return entityManager.CreateArchetype(
            //Transform
            typeof(Position),
            typeof(Rotation),
            typeof(Scale)
            );
    }
    #endregion
}
