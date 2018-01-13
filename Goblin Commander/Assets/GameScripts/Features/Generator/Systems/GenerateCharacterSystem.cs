using Entitas;

public class GenerateCharacterSystem : IInitializeSystem
{
    private readonly GameContext context;

    public GenerateCharacterSystem(Contexts contexts){
        context = contexts.game;
    }

    public void Initialize()
    {
        CreateTestCharacter();
    }

    private void CreateTestCharacter()
    {
        GameEntity testCharacter = context.CreateEntity();
        testCharacter.AddCharacter(CharacterType.goblin);
    }
}