using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AnimateWalk : ReactiveSystem<GameEntity>
{
    public AnimateWalk(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.MoveTarget.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity animatedEntity in entities)
        {
            if (animatedEntity.IsMoving())
            {
                StartWalkAnimation(animatedEntity.animator);
            }
            else
            {
                StopWalkAnimation(animatedEntity.animator);
            }
        }
    }

    private void StartWalkAnimation(Animator animator)
    {
        animator.SetBool(AnimatorConstants.ANIMATOR_KEY_WALK, true);
    }

    private void StopWalkAnimation(Animator animator)
    {
        animator.SetBool(AnimatorConstants.ANIMATOR_KEY_WALK, false);
    }
}