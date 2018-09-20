using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrientViewWhenMovingSystem : ReactiveSystem<GameEntity>
{
    private Vector3 ORIENTATION_RIGHT = new Vector3(-1, 1, 1);
    private Vector3 ORIENTATION_LEFT = new Vector3(1, 1, 1);
    public OrientViewWhenMovingSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.DistanceMoved.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject && entity.isMoving;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity movingEntity in entities)
        {
            Vector3 orientation = movingEntity.distanceMoved.Value.x >= 0
            ? ORIENTATION_RIGHT : ORIENTATION_LEFT;

            movingEntity.gameObject.Value.transform.localScale = orientation;
        }
    }
}