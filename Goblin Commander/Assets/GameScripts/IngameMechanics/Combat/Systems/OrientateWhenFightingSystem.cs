using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrientateWhenFightingSystem : ReactiveSystem<GameEntity>
{
    public OrientateWhenFightingSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        GameEntity attacker = entity.damage.Origin;
        GameEntity defender = entity.damage.Target;
        return attacker.hasOrientationSettings
            && attacker.hasPosition
            && defender.hasPosition;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity damageEntity in entities)
        {
            GameEntity attacker = damageEntity.damage.Origin;
            GameEntity defender = damageEntity.damage.Target;
            Vector2 distance = defender.position.Value - attacker.position.Value;
            OriginalOrientation orientation = distance.x >= 0
            ? OriginalOrientation.Right : OriginalOrientation.Left;

            attacker.ReplaceOrientation(orientation);
        }
    }
}