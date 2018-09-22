using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SetUpOrientationSystem : ReactiveSystem<GameEntity>
{
    private Vector3 ORIENTATION_DEFAULT = new Vector3(1, 1, 1);
    private Vector3 ORIENTATION_OPPOSITE = new Vector3(-1, 1, 1);
    public SetUpOrientationSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            SetUpOrientation(entity);
        }
    }
    private void SetUpOrientation(GameEntity entity)
    {
        OrientationBehaviour originalOrientationBehaviour = entity.gameObject.Value.GetComponent<OrientationBehaviour>();
        if (originalOrientationBehaviour == null)
        {
            return;
        }
        SetUpOrientationSettings(entity, originalOrientationBehaviour.Orientation);
        entity.ReplaceOrientation(originalOrientationBehaviour.Orientation);
    }

    private void SetUpOrientationSettings(GameEntity orientedEntity, OriginalOrientation originalOrientation)
    {
        Vector3 orientationRight;
        Vector3 orientationLeft;
        if (originalOrientation == OriginalOrientation.Right) 
        {
            orientationRight = ORIENTATION_DEFAULT;
            orientationLeft = ORIENTATION_OPPOSITE;
        }
        else
        {
            orientationRight = ORIENTATION_OPPOSITE;
            orientationLeft = ORIENTATION_DEFAULT;
        }
        
        orientedEntity.ReplaceOrientationSettings(
            orientationRight,
            orientationLeft
        );
    }
}