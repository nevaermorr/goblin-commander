using System;
using System.Collections.Generic;
using Entitas;

public class DeathSystem : ReactiveSystem<GameEntity>
{
    public DeathSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CurrentHealth);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCurrentHealth
            && entity.currentHealth <= 0;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity livingEntity in entities)
        {
            livingEntity.isToDestroy = true;
        }
    }
}