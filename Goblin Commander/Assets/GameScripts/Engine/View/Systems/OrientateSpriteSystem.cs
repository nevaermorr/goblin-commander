using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrientateSpriteSystem : ReactiveSystem<GameEntity>
{
    public OrientateSpriteSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Orientation.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasOrientationSettings
            && entity.hasSpriteRenderer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            Orientate(entity);
        }
    }
    private void Orientate(GameEntity entity)
    {
        Vector3 orientedScale = (entity.orientation.Value == OriginalOrientation.Right)
            ? entity.orientationSettings.TransformScaleForRight
            : entity.orientationSettings.TransformScaleForLeft;

        entity.spriteRenderer.Value.transform.localScale = orientedScale;
    }
}