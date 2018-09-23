using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BeaconScareSystem : ReactiveSystem<GameEntity>
{
    public BeaconScareSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Beacon);
    }

    protected override bool Filter(GameEntity beaconEntity)
    {
        return beaconEntity.hasBeacon
            && beaconEntity.beacon.Action == BeaconAction.Scare;
    }

    protected override void Execute(List<GameEntity> beaconEntities)
    {
        foreach (var beaconEntity in beaconEntities)
        {
            ScareCharactersInRange(beaconEntity);
            beaconEntity.isToDestroy = true;
        }
    }

    private void ScareCharactersInRange(GameEntity beaconEntity)
    {
        foreach (GameEntity characterEntity 
            in BeaconService.GetMobileCharacterEntitiesInRange(beaconEntity))
        {
            characterEntity.isScared = true;
            characterEntity.ReplaceMoveTarget(
                GetScaringDestinationPoint(beaconEntity, characterEntity));
        }
    }

    private Vector2 GetScaringDestinationPoint(GameEntity beaconEntity, GameEntity scaredEntity)
    {
        Vector2 direction = (scaredEntity.position.Value - beaconEntity.position.Value).normalized;
        Vector2 pathFromBeacon = direction * beaconEntity.beacon.Range;
        Vector2 destination = beaconEntity.position + pathFromBeacon;
        
        return destination;
    }
}