using Entitas;

public class InitializeBeaconSettingsSystem : IInitializeSystem
{
    private const BeaconAction INIT_BEACON_ACTION = BeaconAction.Summon;

    private GameContext gameContext;

    public InitializeBeaconSettingsSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        gameContext.gameStateEntity.AddBeaconAction(INIT_BEACON_ACTION);
        gameContext.gameStateEntity.AddBeaconRange(BeaconService.GetDefaultRangeForAction(INIT_BEACON_ACTION));
        gameContext.gameStateEntity.AddBeaconCost(BeaconService.GetDefaultCostForAction(INIT_BEACON_ACTION));
    }
}