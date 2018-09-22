using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SetUpAnimatorSystem : ReactiveSystem<GameEntity> {

    public SetUpAnimatorSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject && !entity.hasAnimator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            ExtractAnimator(entity);
        }
    }
    private void ExtractAnimator(GameEntity entity)
    {
        AnimatorLink link = entity.gameObject.Value.GetComponent<AnimatorLink>();
        if (link != null
            && link.Animator != null)
        {
            entity.AddAnimator(link.Animator);
        }
    }
}