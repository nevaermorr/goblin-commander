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

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBeacon;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.beacon.SummonCharactersInRange();
            entity.isToDestroy = true;
        }
    }
}