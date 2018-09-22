using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrientateWhenMovingSystem : ReactiveSystem<GameEntity>
{
    public OrientateWhenMovingSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DistanceMoved.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject && entity.isMoving;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity movingEntity in entities)
        {
            OriginalOrientation orientation = movingEntity.distanceMoved.Value.x >= 0
            ? OriginalOrientation.Right : OriginalOrientation.Left;

            movingEntity.ReplaceOrientation(orientation);
        }
    }
}