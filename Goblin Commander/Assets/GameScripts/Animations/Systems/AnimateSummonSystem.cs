using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class AnimateSummonSystem : ReactiveSystem<GameEntity>
{
    public AnimateSummonSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CharacterType.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterType
            && entity.hasAnimator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity characterEntity in entities)
        {
            StartSummonAnimation(characterEntity.animator);
        }
    }

    private void StartSummonAnimation(Animator animator)
    {
        animator.SetTrigger(AnimatorConstants.ANIMATOR_KEY_SUMMON);
    }
}