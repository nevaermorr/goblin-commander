using UnityEngine;
using Entitas;

public class GenerateCharacterSystem : IInitializeSystem
{
    private readonly GameContext context;

    public GenerateCharacterSystem(Contexts contexts)
    {
        context = contexts.game;
    }

    public void Initialize()
    {
        CreateTestPlayerAt(new Vector2(1, 1));
        CreateTestEnemyAt(new Vector2(5, 5));
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
    }

    private GameEntity CreateTestCharacter(Faction faction)
    {
        GameEntity testCharacter = context.CreateEntity();
        testCharacter.AddGameObjectRequest(faction + " Goblin");
        testCharacter.AddCharacterType(CharacterType.goblin);
        testCharacter.AddMobility(2f);
        testCharacter.AddPosition(Vector2.zero);
        testCharacter.AddFaction(faction);
        testCharacter.AddSightRange(1f);
        testCharacter.AddAttack(1f, 0.5f, 1f);

        return testCharacter;
    }
}