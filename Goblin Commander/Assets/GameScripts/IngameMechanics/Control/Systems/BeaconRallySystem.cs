using System.Linq;
using System.Collections.Generic;
using Entitas;

public class BeaconRallySystem : ReactiveSystem<GameEntity>
{
    public BeaconRallySystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Beacon);
    }

    protected override bool Filter(GameEntity beaconEntity)
    {
        return beaconEntity.hasBeacon
            && beaconEntity.beacon.Action == BeaconAction.Rally;
    }

    protected override void Execute(List<GameEntity> beaconEntities)
    {
        foreach (var beaconEntity in beaconEntities)
        {
            SummonCharactersInRange(beaconEntity);
            beaconEntity.isToDestroy = true;
        }
    }

    private void SummonCharactersInRange(GameEntity beaconEntity)
    {
        foreach (GameEntity characterEntity
            in BeaconService.GetMobileCharacterEntitiesInRange(beaconEntity))
        {
            if (!beaconEntity.BelongsToFactionOf(characterEntity))
            {
                continue;
            }
            characterEntity.ReplaceMoveTarget(beaconEntity.position);
        }
    }
}