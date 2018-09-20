using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class UpdatePositionSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> spatialEntities;
    public UpdatePositionSystem(Contexts contexts)
    {
        spatialEntities = contexts.game.GetGroup(GameMatcher.AllOf(
            GameMatcher.Position,
            GameMatcher.GameObject
        ));
    }

    public void Execute()
    {
        foreach (GameEntity entity in spatialEntities)
        {
            Vector2 newPosition = entity.gameObject.Value.transform.position;

            entity.ReplaceDistanceMoved(newPosition - entity.position);
            entity.isMoving = (newPosition != entity.position);
            entity.ReplacePosition(newPosition);
        }
    }
}