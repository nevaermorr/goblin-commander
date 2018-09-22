using System.Linq;
using System.Collections.Generic;
using Entitas;

public class SummonCharacterToBeaconSystem : ReactiveSystem<GameEntity>
{
    public SummonCharacterToBeaconSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Beacon);
    }

    protected override bool Filter(GameEntity beaconEntity)
    {
        return beaconEntity.hasBeacon;
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
        foreach (GameEntity characterEntity in GetMobileCharacterEntitiesInRange(beaconEntity))
        {
            if (!beaconEntity.BelongsToFactionOf(characterEntity))
            {
                continue;
            }
            characterEntity.ReplaceMoveTarget(beaconEntity.position);
        }
    }
    
    public static GameEntity[] GetMobileCharacterEntitiesInRange(GameEntity beaconEntity)
    {
        return MovementService.GetAllMobileCharacterEntities()
        .Where(entity => entity.position.IsInRangeOf(beaconEntity.position, beaconEntity.beacon.Range)).ToArray();
    }
}