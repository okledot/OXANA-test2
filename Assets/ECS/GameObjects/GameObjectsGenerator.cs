using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Physics;
using Movement;
using GameObjects;
using UnityEngine;

public static class GameObjectsGenerator
{
    public static void ImportPlayer(EntityManager em, EntityArchetype playerArchetype, InitializeSettings initSettings)
    {
        var playerEntity = em.CreateEntity(playerArchetype);
        em.SetComponentData(playerEntity, initSettings.playerStats.position);
        em.SetComponentData(playerEntity, initSettings.playerStats.scale);
        em.SetComponentData(playerEntity, initSettings.playerStats.rotation);
        em.SetComponentData(playerEntity, new AABBCollider { Size = initSettings.playerStats.aabbcollider });
        em.SetComponentData(playerEntity, new RigidbodyComponent { Mass = initSettings.playerStats.rigidbody });
        em.SetComponentData(playerEntity, new Velocity { Value = initSettings.playerStats.velocity });
        em.SetComponentData(playerEntity, new Health { Value = initSettings.playerStats.health });
        em.SetComponentData(playerEntity, new Damage { Value = initSettings.playerStats.damage });
        em.AddSharedComponentData(playerEntity, initSettings.playerStats.render);
    }

    public static void ImportEnemy(EntityManager em, EntityArchetype enemyArchetype, InitializeSettings initSettings)
    {
        var enemyEntity = em.CreateEntity(enemyArchetype);
        em.SetComponentData(enemyEntity, initSettings.enemyStats.position);
        em.SetComponentData(enemyEntity, initSettings.enemyStats.scale);
        em.SetComponentData(enemyEntity, initSettings.enemyStats.rotation);
        em.SetComponentData(enemyEntity, new AABBCollider { Size = initSettings.playerStats.aabbcollider });
        em.SetComponentData(enemyEntity, new RigidbodyComponent { Mass = initSettings.playerStats.rigidbody });
        em.SetComponentData(enemyEntity, new Velocity { Value = initSettings.playerStats.velocity });
        em.SetComponentData(enemyEntity, new Health { Value = initSettings.playerStats.health });
        em.SetComponentData(enemyEntity, new Damage { Value = initSettings.playerStats.damage });
        em.AddSharedComponentData(enemyEntity, initSettings.enemyStats.render);
    }

    public static void ImportItem(EntityManager em, EntityArchetype itemArchetype, InitializeSettings initSettings)
    {
        var itemEntity = em.CreateEntity(itemArchetype);
        em.SetComponentData(itemEntity, initSettings.itemStats.position);
        em.SetComponentData(itemEntity, initSettings.itemStats.scale);
        em.SetComponentData(itemEntity, initSettings.itemStats.rotation);
        em.SetComponentData(itemEntity, new AABBCollider { Size = initSettings.itemStats.aabbcollider });
        em.SetComponentData(itemEntity, new RigidbodyComponent { Mass = initSettings.itemStats.rigidbody });
        em.AddSharedComponentData(itemEntity, initSettings.itemStats.render);
    }
}
