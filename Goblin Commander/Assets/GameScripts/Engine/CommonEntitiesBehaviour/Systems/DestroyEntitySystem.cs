using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public interface IToDestroyMultiEntity : IEntity, IToDestroyEntity { }

// Required for multi-context system.
public partial class GameEntity : IToDestroyMultiEntity { }
public partial class InputEntity : IToDestroyMultiEntity { }

public class DestroyEntitySystem : MultiReactiveSystem<IToDestroyMultiEntity, Contexts>
{
    public DestroyEntitySystem(Contexts contexts) : base (contexts) { }

    protected override ICollector[] GetTrigger(Contexts contexts)
    {
        return new ICollector[]
        {
            contexts.game.CreateCollector(GameMatcher.ToDestroy),
            contexts.input.CreateCollector(InputMatcher.ToDestroy)
        };
    }

    protected override bool Filter(IToDestroyMultiEntity entity)
    {
        return entity.isToDestroy;
    }

    protected override void Execute(List<IToDestroyMultiEntity> entities)
    {
        foreach (var entity in entities)
        {
            DestroyAttachedGameObject(entity);
            entity.Destroy();
        }
    }

    private void DestroyAttachedGameObject(IToDestroyEntity entity)
    {
        if (!(entity is GameEntity))
        {
            return;
        }
        GameEntity gameEntity = entity as GameEntity;

        if (gameEntity.hasGameObject) {
            GameObject gameObject = gameEntity.gameObject.Value;
            gameObject.Unlink();
            GameObject.Destroy(gameObject);
        }
    }
    
}