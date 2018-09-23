using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ScareSystem : ReactiveSystem<GameEntity>
{
    public ScareSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Scared.Added());
    }

    protected override bool Filter(GameEntity scaredEntity)
    {
        return scaredEntity.hasCurrentEnemy;
    }

    protected override void Execute(List<GameEntity> scaredEntities)
    {
        foreach (var scaredEntity in scaredEntities)
        {
            scaredEntity.RemoveCurrentEnemy();
        }
    }
}