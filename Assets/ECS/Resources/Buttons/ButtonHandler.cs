using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    

    public void ReLoadScene()
    {
        EntityManager em = World.Active.GetOrCreateManager<EntityManager>();
        InitializeSettings initSettings = InitializeSettings.LoadFromResources();

        EntityArchetype playerArchetype;
        EntityArchetype enemyArchetype;
        EntityArchetype itemArchetype;
        EntityArchetype blockArchetype;
        EntityArchetype waterArchetype;


        int levelLength = initSettings.levelLength;
        int levelHeight = initSettings.levelHeight;
        NativeArray<Entity> sector = new NativeArray<Entity>(500, Allocator.Temp);
        sector = em.GetAllEntities(Allocator.Temp);
        for (int i = 0; i < sector.Length; i++) { em.DestroyEntity(sector[i]); }

        playerArchetype = ObjectsEntityFactory.CreatePlayerArchetype(em);
        enemyArchetype = ObjectsEntityFactory.CreateEnemyArchetype(em);
        itemArchetype = ObjectsEntityFactory.CreateItemArchetype(em);
        blockArchetype = ObjectsEntityFactory.CreateBlockArchetype(em);
        waterArchetype = ObjectsEntityFactory.CreateWaterArchetype(em);

        LevelGenerator.ImportWater(em, waterArchetype, initSettings);

        LevelGenerator.ImportMap(em, blockArchetype, initSettings);

        GameObjectsGenerator.ImportPlayer(em, playerArchetype, initSettings);
        GameObjectsGenerator.ImportEnemy(em, enemyArchetype, initSettings);
        GameObjectsGenerator.ImportItem(em, itemArchetype, initSettings);
    }

    private static int BlocksCount(int Length, int Height)
    {
        int count = (int)math.pow(Length, 2) * Height;
        return count;
    }
}
