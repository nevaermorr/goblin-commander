using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateObstaclePrefabSystem : ReactiveSystem<GameEntity> {

    private GameContext gameContext;

    public InstantiateObstaclePrefabSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

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
        foreach (GameEntity entity in entities)
        {
            GameObject obstacleObject = Object.Instantiate(
                ObstaclePrefabService.GetPrefabForType(entity.obstacleType)
            ) as GameObject;
            // TODO move linking to separate system.
            obstacleObject.Link(entity, gameContext);

            entity.AddGameObject(obstacleObject);
            PutInPosition(obstacleObject, entity);
        }
    }

    // TODO use trackedPosition / forcedPosition (or initPosition?) to differentiate.
    private void PutInPosition(GameObject characterObject, GameEntity entity)
    {
        if (entity.hasPosition)
        {
            characterObject.transform.position = entity.position;
        }
    }
}