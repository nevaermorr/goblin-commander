using UnityEngine;
using Entitas;

public class GenerateCharacterSystem : IInitializeSystem
{
    private readonly GameContext gameContext;

    public GenerateCharacterSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        CreateTestPlayerAt(new Vector2(1, 1));
        CreateTestEnemyAt(new Vector2(5, 2));
    }

    private void CreateTestPlayerAt(Vector2 position)
    {
        GameEntity testCharacter = CreateTestCharacter(Faction.Player);
        testCharacter.ReplacePosition(position);
    }

    private void CreateTestEnemyAt(Vector2 position)
    {
        GameEntity testCharacter = CreateTestCharacter(Faction.Enemy);
        testCharacter.ReplacePosition(position);
        testCharacter.ReplaceAttack(0.1f, 0.5f, 1f);
    }

    private GameEntity CreateTestCharacter(Faction faction)
    {
        GameEntity testCharacter = gameContext.CreateEntity();
        testCharacter.AddCharacterType(CharacterType.goblin);
        testCharacter.AddMobility(2f);
        testCharacter.AddPosition(Vector2.zero);
        testCharacter.AddFaction(faction);
        testCharacter.AddSightRange(1f);
        testCharacter.AddAttack(0.1f, 0.5f, 0.5f);
        testCharacter.AddHealth(5f);

        return testCharacter;
    }
}