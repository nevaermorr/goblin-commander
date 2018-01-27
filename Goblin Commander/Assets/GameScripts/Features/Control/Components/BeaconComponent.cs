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
            characterEntity.ReplaceMoveTarget(beaconPosition);
        }
    }

    private GameEntity[] GetMobileCharacterEntitiesInRange()
    {
        return GetAllMobileCharacterEntities().Where(IsEntityInRange).ToArray();
    }

    // TODO this should to some more appropriate scope.
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