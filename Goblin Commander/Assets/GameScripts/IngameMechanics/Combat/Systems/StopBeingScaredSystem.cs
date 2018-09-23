using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class StopBeingScaredSystem : ReactiveSystem<GameEntity>
{
    public StopBeingScaredSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveTarget.Removed());
    }

    protected override bool Filter(GameEntity stoppedEntity)
    {
        return stoppedEntity.isScared;
    }

    protected override void Execute(List<GameEntity> stoppedEntities)
    {
        foreach (var stoppedEntity in stoppedEntities)
        {
            stoppedEntity.isScared = false;
        }
    }
}