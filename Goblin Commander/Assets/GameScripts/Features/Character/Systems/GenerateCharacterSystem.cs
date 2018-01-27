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
        CreateTestCharacter();
    }

    private void CreateTestCharacter()
    {
        GameEntity testCharacter = context.CreateEntity();
        testCharacter.AddGameObjectRequest("Goblin");
        testCharacter.AddCharacterType(CharacterType.goblin);
        testCharacter.AddPosition(Vector2.zero);
        testCharacter.AddMobility(2f);
    }
}