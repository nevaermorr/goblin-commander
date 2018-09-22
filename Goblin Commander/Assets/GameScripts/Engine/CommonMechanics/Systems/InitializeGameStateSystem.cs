using Entitas;

public class InitializeGameStateSystem : IInitializeSystem
{
    private GameContext gameContext;
    public InitializeGameStateSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        GameEntity gameStateEntity = gameContext.CreateEntity();
        gameStateEntity.isGameState = true;
    }
}