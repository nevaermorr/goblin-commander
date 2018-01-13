using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class RemoveGameObjectSystem : ReactiveSystem<GameEntity> {

    public RemoveGameObjectSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Removed());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            GameObject.Destroy(entity.gameObject.Value);
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