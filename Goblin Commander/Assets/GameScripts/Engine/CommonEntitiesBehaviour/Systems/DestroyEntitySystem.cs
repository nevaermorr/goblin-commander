using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public interface IToDestroyEntity : IEntity, IToDestroy { }

// Required for multi-context system.
public partial class GameEntity : IToDestroyEntity { }
public partial class InputEntity : IToDestroyEntity { }

public class DestroyEntitySystem : MultiReactiveSystem<IToDestroyEntity, Contexts>
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

    protected override bool Filter(IToDestroyEntity entity)
    {
        return entity.isToDestroy;
    }

    protected override void Execute(List<IToDestroyEntity> entities)
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