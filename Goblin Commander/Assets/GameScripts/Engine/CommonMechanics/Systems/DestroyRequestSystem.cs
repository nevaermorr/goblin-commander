using System.Collections.Generic;
using Entitas;

public class DestroyRequestSystem : ReactiveSystem<GameEntity>
{
    public DestroyRequestSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Request);
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity requestEntity in entities)
        {
            requestEntity.isToDestroy = true;
        }
    }
}