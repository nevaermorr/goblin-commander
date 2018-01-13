using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class UpdatePositionSystem : ReactiveSystem<GameEntity>
{
    public UpdatePositionSystem(Contexts contexts) : base(contexts.game) { }
	
	    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Position.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasPosition && entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            entity.gameObject.Value.transform.position = entity.position.Value;
        }
    }
}