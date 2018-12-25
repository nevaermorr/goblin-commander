using Entitas;

public class InitEnergySystem : IInitializeSystem
{
    private readonly GameContext gameContext;
    public InitEnergySystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        gameContext.gameStateEntity.AddEnergy(
            gameContext.settingsEntity.globalSettings.Value.StartingEnergy
        );
    }
}