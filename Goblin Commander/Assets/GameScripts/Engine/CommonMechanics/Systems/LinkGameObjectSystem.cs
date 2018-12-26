using System.Collections.Generic;
using Entitas;
using Entitas.Unity;

public class LinkGameObjectSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext gameContext;
    public LinkGameObjectSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(GameEntity entity in entities)
        {
            LinkEntity(entity);
        }
    }

    private void LinkEntity(GameEntity entity)
    {
        entity.gameObject.Value.Link(entity, gameContext);
    }
}