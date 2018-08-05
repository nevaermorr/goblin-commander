using UnityEngine;
using Entitas;

public class GenerateObstacleSystem : IInitializeSystem
{
    private readonly GameContext gameContext;

    public GenerateObstacleSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        CreateCrateAt(new Vector2(3.8f, 2f));
        CreateCrateAt(new Vector2(4.2f, 2f));
        CreateCrateAt(new Vector2(4.6f, 2f));
        CreateCrateAt(new Vector2(4.6f, 1.85f));
        CreateCrateAt(new Vector2(4.6f, 1.7f));
    }

    private void CreateCrateAt(Vector2 position)
    {
        GameEntity crateEntity = gameContext.CreateEntity();
        crateEntity.AddObstacleType(ObstacleType.crate);
        crateEntity.AddPosition(position);
    }
}