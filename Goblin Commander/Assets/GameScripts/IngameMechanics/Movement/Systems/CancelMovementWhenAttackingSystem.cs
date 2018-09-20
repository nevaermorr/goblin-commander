using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CancelMovementWhenAttackingSystem : ReactiveSystem<GameEntity>
{
    public CancelMovementWhenAttackingSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity damageEntity in entities)
        {
            GameEntity attacker = damageEntity.damage.Origin;
            attacker.CancelMovement();
        }
    }
}