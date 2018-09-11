using System;
using System.Collections.Generic;
using Entitas;

public class HealthbarUpdateSystem : ReactiveSystem<GameEntity>
{
    public HealthbarUpdateSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject 
            && entity.hasMaxHealth;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity damageEntity in entities)
        {
            HandleDamage(damageEntity.damage);
            damageEntity.isToDestroy = true;
        }
    }

    private void HandleDamage(DamageComponent damage)
    {
        try{
            CheckIfDamagable(damage.Target);
            damage.Target.ReplaceCurrentHealth(
                damage.Target.currentHealth - damage.Value
            );
        }
        catch {}
    }

    private void CheckIfDamagable(GameEntity targetEntity)
    {
        if (!targetEntity.hasCurrentHealth)
        {
            throw new Exception();
        }
    }
}