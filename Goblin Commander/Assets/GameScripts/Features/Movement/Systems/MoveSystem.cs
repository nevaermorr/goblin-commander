using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveSystem : ReactiveSystem<GameEntity>
{
    public MoveSystem(Contexts contexts) : base(contexts.game) { } 

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(
            GameMatcher.MoveTarget,
            GameMatcher.Mobility,
            GameMatcher.Position
        ));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMoveTarget && entity.hasMobility;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities) {
            Move(entity);
        }
    }

    private void Move(GameEntity entity) {
        Vector2 path = entity.moveTarget.Value - entity.position.Value;
        float stepLength = entity.mobility.MovementSpeed * Time.deltaTime;
        if (stepLength >= path.magnitude)
        {
            ArriveAtDestination(entity);
        }
        else {
            MakeStep(entity, path.normalized * stepLength);
        }
    }

    private void ArriveAtDestination(GameEntity entity)
    {
        entity.ReplacePosition(entity.moveTarget);
        entity.RemoveMoveTarget();
    }

    private void MakeStep(GameEntity entity, Vector2 step)
    {
        entity.ReplacePosition(entity.position + step);
    }
}