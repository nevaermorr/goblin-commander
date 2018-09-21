using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class SightRangeComponent : IComponent
{
    public float Value;

    public static implicit operator float(SightRangeComponent sightRangeComponent)
    {
        return sightRangeComponent.Value;
    }
}

public partial class GameEntity
{
    public List<GameEntity> GetEntitiesInSight()
    {
        if (!this.IsValidSightRangeEntity())
        {
            return new List<GameEntity>();
        }
        return GetEntitiesInSightForValidEntity();
    }

    private bool IsValidSightRangeEntity()
    {
        return this.hasSightRange && this.hasPosition;
    }

    private List<GameEntity> GetEntitiesInSightForValidEntity()
    {
        List<GameEntity> entitiesInSight = new List<GameEntity>();
        foreach (var positionEntity 
            in Contexts.sharedInstance.game.GetGroup(GameMatcher.Position).GetEntities())
        {
            if (positionEntity.position.IsInRangeOf(this.position, this.sightRange))
            {
                entitiesInSight.Add(positionEntity);
            }
        }
        return entitiesInSight;
    }
}