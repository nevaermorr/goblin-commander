using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CancelMovementWhenStuckSystem : ReactiveSystem<GameEntity>
{
    private const float MINIMAL_DISTANCE_PER_SECOND = 0.01f;
    public CancelMovementWhenStuckSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DistanceMoved.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMoveTarget;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity movingEntity in entities)
        {
            if (MovementIsTooSlow(movingEntity))
            {
                movingEntity.CancelMovement();
            }
        }
    }

    private bool MovementIsTooSlow(GameEntity movingEntity)
    {
        return movingEntity.distanceMoved.Value.magnitude / Time.deltaTime < MINIMAL_DISTANCE_PER_SECOND;
    }
}