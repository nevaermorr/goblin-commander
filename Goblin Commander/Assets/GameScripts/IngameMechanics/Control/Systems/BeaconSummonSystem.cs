using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BeaconSummonSystem : ReactiveSystem<GameEntity>
{
    public BeaconSummonSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Beacon);
    }

    protected override bool Filter(GameEntity beaconEntity)
    {
        return beaconEntity.hasBeacon
            && beaconEntity.beacon.Action == BeaconAction.Summon
            && beaconEntity.hasPosition;
    }

    protected override void Execute(List<GameEntity> beaconEntities)
    {
        foreach (var beaconEntity in beaconEntities)
        {
            SummonNewGoblin(beaconEntity.position);
            beaconEntity.isToDestroy = true;
        }
    }

    private void SummonNewGoblin(Vector2 position)
    {
        RequestsService.CreateRequestEntity()
            .AddGenerateCharacterRequest(
                position,
                Faction.Player,
                CharacterType.goblin
            );
    }
}