using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Rendering;
using Unity.Transforms;
//using PhysicsEngine;

public sealed class TestSceneInitializer
{
    /// <summary>
    /// Объявление переменных
    /// </summary>

    static public EntityManager entityManager;
    static public InitializeSettings initSettings;

    public static EntityArchetype playerArchetype;
    public static EntityArchetype enemyArchetype;
    public static EntityArchetype itemArchetype;
    public static EntityArchetype blockArchetype;
    public static EntityArchetype waterArchetype;

    /// <summary>
    /// Методы подготовки к загрузке и образованию сцены
    /// Создание архетипов
    /// </summary>

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Initialize()
    {
        entityManager = World.Active.GetOrCreateManager<EntityManager>();
        LoadArchetypes(entityManager);
    }

    #region "Метод загрузки архетипов LoadArchetypes();"
    private static void LoadArchetypes(EntityManager em)
    {
        playerArchetype = ObjectsEntityFactory.CreatePlayerArchetype(em);
        enemyArchetype = ObjectsEntityFactory.CreateEnemyArchetype(em);
        itemArchetype = ObjectsEntityFactory.CreateItemArchetype(em);
        blockArchetype = ObjectsEntityFactory.CreateBlockArchetype(em);
        waterArchetype = ObjectsEntityFactory.CreateWaterArchetype(em);
    }
    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void InitializeWithScene()
    {
        initSettings = InitializeSettings.LoadFromResources();
        entityManager = World.Active.GetOrCreateManager<EntityManager>();

        LevelGenerator.ImportWater(entityManager, waterArchetype, initSettings);
        LevelGenerator.ImportMap(entityManager, blockArchetype, initSettings);

        GameObjectsGenerator.ImportPlayer(entityManager, playerArchetype, initSettings);
        GameObjectsGenerator.ImportEnemy(entityManager, enemyArchetype, initSettings);
        GameObjectsGenerator.ImportItem(entityManager, itemArchetype, initSettings);

    }


}
