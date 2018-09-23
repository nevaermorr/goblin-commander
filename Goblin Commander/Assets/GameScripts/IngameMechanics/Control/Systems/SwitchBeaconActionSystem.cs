using System.Linq;
using System.Collections.Generic;
using Entitas;

public class SwitchBeaconActionSystem : ReactiveSystem<GameEntity>
{
    private GameContext gameContext;
    public SwitchBeaconActionSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.SwitchBeaconActionRequest.Added());
    }

    protected override bool Filter(GameEntity beaconEntity)
    {
        return true;
    }

    protected override void Execute(List<GameEntity> requestEntities)
    {
        foreach (var requestEntity in requestEntities)
        {
            BeaconAction newAction = requestEntity.switchBeaconActionRequest.NewBeaconAction;
            gameContext.gameStateEntity.ReplaceBeaconAction(newAction);
            gameContext.gameStateEntity.ReplaceBeaconRange(
                BeaconService.GetDefaultRangeForAction(newAction)
            );
        }
    }
}