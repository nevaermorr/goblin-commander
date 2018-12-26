using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateObstaclePrefabSystem : ReactiveSystem<GameEntity> {

    public InstantiateObstaclePrefabSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ObstacleType);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasObstacleType;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity obstacleEntity in entities)
        {
            InstantiateObstacleGameObject(obstacleEntity);
        }
    }

    private void InstantiateObstacleGameObject(GameEntity obstacleEntity)
    {
        ObstacleType obstacleType = obstacleEntity.obstacleType.Value;
        ObstacleSettings obstacleSettings = SettingsService.GetObstacleSettings(obstacleType);

        GameObject obstacleObject = Object.Instantiate(
            obstacleSettings.Prefab
        ) as GameObject;

        obstacleEntity.AddGameObject(obstacleObject);
        PutInPosition(obstacleObject, obstacleEntity);
    }

    // TODO use trackedPosition / forcedPosition (or initPosition?) to differentiate.
    private void PutInPosition(GameObject obstacleObject, GameEntity entity)
    {
        if (entity.hasPosition)
        {
            obstacleObject.transform.position = entity.position;
        }
    }
}