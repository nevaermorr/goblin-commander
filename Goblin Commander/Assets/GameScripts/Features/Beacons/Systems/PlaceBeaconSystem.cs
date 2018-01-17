using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PlaceBeaconSystem : ReactiveSystem<InputEntity>
{
    private readonly GameContext gameContext;
    private readonly InputContext inputContext;

    public PlaceBeaconSystem(Contexts contexts) : base(contexts.input)
    { 
        gameContext = contexts.game;
        inputContext = contexts.input;
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
            GameEntity beacon = gameContext.CreateEntity();
            beacon.AddBeacon(5f);
            beacon.AddPosition(entity.position.Value);
            Debug.Log("dropping beacon at " + entity.position.Value);
        }
    }
}