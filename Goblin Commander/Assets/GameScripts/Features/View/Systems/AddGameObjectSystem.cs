using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class AddGameObjectSystem : ReactiveSystem<GameEntity> {

    private GameContext context;

    public AddGameObjectSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObjectRequest.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObjectRequest;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            if (entity.hasGameObject) {
                entity.gameObject.Value.name = entity.gameObjectRequest.Name;
            }
            GameObject gameObject = new GameObject(entity.gameObjectRequest.Name);
            gameObject.Link(entity, context);
            entity.AddGameObject(gameObject);
            entity.RemoveGameObjectRequest();
        }
    }

    private SpriteRenderer GetOrAddSpriteRenderer(GameObject gameObject)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }
        return spriteRenderer;
    }
}