using UnityEngine;
using Entitas;

public class InitializeCharactersSystem : IInitializeSystem
{
    public InitializeCharactersSystem(Contexts contexts) {}

    public void Initialize()
    {
        CreateTestPlayerAt(new Vector2(1, 1)); 
        CreateTestPlayerAt(new Vector2(1, 2)); 
        CreateTestEnemyAt(new Vector2(5, 2));
    }

    private void CreateTestPlayerAt(Vector2 position)
    {
        RequestsService.CreateRequestEntity()
            .AddGenerateCharacterRequest(
                position,
                Faction.Player,
                CharacterType.goblin
            );
    }

    private void CreateTestEnemyAt(Vector2 position)
    {
        RequestsService.CreateRequestEntity()
            .AddGenerateCharacterRequest(
                position,
                Faction.Enemy,
                CharacterType.goblin
            );
    }
}