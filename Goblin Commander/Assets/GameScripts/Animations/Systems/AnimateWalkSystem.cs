using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AnimateMovementSystem : ReactiveSystem<GameEntity>
{
    public AnimateMovementSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Moving.AddedOrRemoved());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasAnimator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity animatedEntity in entities)
        {
            if (animatedEntity.isMoving)
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