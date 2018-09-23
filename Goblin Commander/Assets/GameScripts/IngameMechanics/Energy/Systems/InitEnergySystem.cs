using Entitas;

public class InitEnergySystem : IInitializeSystem
{
    private const float INITIAL_ENERGY = 10f;
    private readonly GameContext gameContext;
    public InitEnergySystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        gameContext.gameStateEntity.AddEnergy(INITIAL_ENERGY);
    }
}