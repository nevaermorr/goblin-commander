using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SetUpSpriteRendererSystem : ReactiveSystem<GameEntity> {

    public SetUpSpriteRendererSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject && !entity.hasSpriteRenderer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            ExtractSpriteRenderer(entity);
        }
    }
    private void ExtractSpriteRenderer(GameEntity entity)
    {
        SpriteRenderer spriteRenderer = entity.gameObject.Value.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            entity.AddSpriteRenderer(spriteRenderer);
        }
    }
}