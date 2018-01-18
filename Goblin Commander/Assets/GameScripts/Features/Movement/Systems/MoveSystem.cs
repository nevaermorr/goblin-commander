using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class MoveSystem : ReactiveSystem<GameEntity>
{
    public MoveSystem(Contexts contexts) : base(contexts.game) { } 

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(
            GameMatcher.Move,
            GameMatcher.Position
        ));
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMove;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities) {
            Move(entity);
        }
    }

    private void Move(GameEntity entity) {
        Vector2 path = entity.move.Target - entity.position.Value;
        float stepLength = entity.move.Speed * Time.deltaTime;
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
        entity.ReplacePosition(entity.move.Target);
        entity.RemoveMove();
    }

    private void MakeStep(GameEntity entity, Vector2 step)
    {
        entity.ReplacePosition(entity.position.Value + step);
    }
}