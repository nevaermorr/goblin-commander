using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class UpdateSpriteSystem : ReactiveSystem<GameEntity> {
    public UpdateSpriteSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && entity.hasGameObject;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            SpriteRenderer spriteRenderer = GetOrAddSpriteRenderer(entity.gameObject);
            spriteRenderer.sprite = entity.sprite;
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