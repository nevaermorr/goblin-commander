using System.Linq;
using UnityEngine;
using Entitas;

[Game]
public class BeaconComponent : IComponent{
    public GameEntity Entity;

    public float Range;
    private PositionComponent beaconPosition
    {
        get { 
            return Entity.position;
        }
    }

    public void SummonCharactersInRange()
    {
        foreach (GameEntity characterEntity in GetMobileCharacterEntitiesInRange())
        {
            if (!BelongsToRelevantFactionFor(characterEntity))
            {
                continue;
            }
            characterEntity.ReplaceMoveTarget(beaconPosition);
        }
    }

    private bool BelongsToRelevantFactionFor(GameEntity characterEntity)
    {
        return (
            !this.Entity.hasFaction
            || characterEntity.BelongsToFaction(this.Entity.faction)
        );
    }

    private GameEntity[] GetMobileCharacterEntitiesInRange()
    {
        return GetAllMobileCharacterEntities().Where(IsEntityInRange).ToArray();
    }

    // TODO this should go to some more appropriate scope.
    private GameEntity[] GetAllMobileCharacterEntities()
    {
        return Contexts.sharedInstance.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Position,
                GameMatcher.CharacterType,
                GameMatcher.Mobility
            )).GetEntities();
    }

    private bool IsEntityInRange(GameEntity entity)
    {
        return entity.position.IsInRangeOf(beaconPosition, Range);
    }
}