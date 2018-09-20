using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AnimateAttackSystem : ReactiveSystem<GameEntity>
{
    public AnimateAttackSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return AttackerIsAnimated(entity);
    }

    private bool AttackerIsAnimated(GameEntity damageEntity)
    {
        return damageEntity.damage.Origin.hasAnimator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity damageEntity in entities)
        {
            GameEntity attackerEntity = damageEntity.damage.Origin;
            StartAttackAnimation(attackerEntity.animator);
        }
    }

    private void StartAttackAnimation(Animator animator)
    {
        animator.SetTrigger(AnimatorConstants.ANIMATOR_KEY_ATTACK);
    }
}