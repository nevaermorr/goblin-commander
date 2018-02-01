using System;
using System.Collections.Generic;
using Entitas;

public class DamageSystem : ReactiveSystem<GameEntity>
{
    public DamageSystem(Contexts contexts) : base(contexts.game)
    {
    }

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
            HandleDamage(damageEntity.damage);
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
        catch (Exception e) { }
    }

    private void CheckIfDamagable(GameEntity targetEntity)
    {
        if (!targetEntity.hasCurrentHealth)
        {
            throw new Exception();
        }
    }

    private void SubtractHealth()
    {

    }
}