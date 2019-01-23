using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Collections;
using Random = UnityEngine.Random;

public static class LevelGenerator
{

    /// <summary>
    /// Методы Добавления объектов мира
    /// </summary>
    /// <param name="em"></param>
    /// <param name="blockArchetype"></param>
    /// <param name="initSettings"></param>

    #region // Метод импорта карты ImportMap();
    public static void ImportMap(EntityManager em, EntityArchetype blockArchetype, InitializeSettings initSettings)
    {
        int levelLength = initSettings.levelLength;
        int levelHeight = initSettings.levelHeight;
        int k = 0;

        Position startPosition = initSettings.blockStats.position;
        Position spawnPosition;
        Scale scale = initSettings.blockStats.scale;
        MeshInstanceRenderer renderBlock = initSettings.blockStats.render;


        NativeArray<Entity> sector = new NativeArray<Entity>(BlocksCount(levelLength, levelHeight), Allocator.Temp);
        bool[] sectorStatus = new bool[BlocksCount(levelLength, levelHeight)];
        for (int i = 0; i < BlocksCount(levelLength, levelHeight); i++) { sectorStatus[i] = false; }

            em.CreateEntity(blockArchetype, sector);
        for (int _y = 0; _y < levelHeight; _y++)
        {
            for (int _z = 0; _z < levelLength; _z++)
            {
                for (int _x = 0; _x < levelLength; _x++)
                {
                    spawnPosition = NextPosition(_x, _y, _z, scale, startPosition);
                    em.SetComponentData(sector[k], spawnPosition);
                    em.SetComponentData(sector[k], scale);
                    k = AddSector(em, sector[k], scale, renderBlock, levelLength, _y, k, sectorStatus);
                }
            }
        }
        Debug.Log("K: " + k);
        sector.Dispose();
    }
    #endregion

    #region // Метод импорта карты ImportWater();
    public static void ImportWater(EntityManager em, EntityArchetype waterArchetype, InitializeSettings initSettings)
    {
        var waterEntity = em.CreateEntity(waterArchetype);

        em.SetComponentData(waterEntity, initSettings.waterStats.position);
        em.SetComponentData(waterEntity, initSettings.waterStats.scale);
        em.SetComponentData(waterEntity, initSettings.waterStats.rotation);
        em.AddSharedComponentData(waterEntity, initSettings.waterStats.render);


    }
    #endregion

    //---------------------------------

    /// <summary>
    /// Приватные классы для методов
    /// </summary>
    /// <param name="Length"></param>
    /// <param name="Height"></param>
    /// <returns></returns>
   
    #region //Просчёт общего количество блоков
    private static int BlocksCount (int Length, int Height)
    {
        int count = (int)math.pow(Length, 2) * Height;
        return count;
    }
    #endregion

    #region //Просчёт следующей позиции блока
    private static Position NextPosition (float x, float y, float z, Scale size, Position start )
    {
        float startX = start.Value.x;
        float startY = start.Value.y;
        float startZ = start.Value.z;

        Position nextPosition = new Position { Value = new float3(startX + (x * size.Value.x + 1),startY + y*size.Value.y, startZ + (z * size.Value.z + 1)) };
        return nextPosition;
    }
    #endregion

    #region //Метод добавления Меша к сущности сектора
    private static int AddSector (EntityManager em, Entity entity, Scale scale, MeshInstanceRenderer render, int levelLength, int floor, int k, bool[] status)
    {
        if (floor == 0) { em.AddSharedComponentData(entity, render); status[k] = true; }
        else
        {
            if ((Random.Range(0, 100) < 100/floor) && (status[k-(int)math.pow(levelLength, 2)] == true)) 
            {
                { em.AddSharedComponentData(entity, render); status[k] = true;}
            }
        }
        k++;
        return k;
    }
    #endregion
}
