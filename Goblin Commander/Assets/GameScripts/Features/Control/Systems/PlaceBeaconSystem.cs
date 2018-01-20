using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlaceBeaconSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext gameContext;

    public PlaceBeaconSystem(Contexts contexts) : base(contexts.input)
    { 
        gameContext = contexts.game;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(
            InputMatcher.MouseLeft, InputMatcher.MousePressed));
    }

    protected override bool Filter(InputEntity entity)
    {
        return true;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (InputEntity entity in entities)
        {
            GameEntity beaconEntity = gameContext.CreateEntity();
            beaconEntity.AddPosition(entity.position.Value);
            beaconEntity.AddBeacon(beaconEntity, 5f);
        }
    }
}