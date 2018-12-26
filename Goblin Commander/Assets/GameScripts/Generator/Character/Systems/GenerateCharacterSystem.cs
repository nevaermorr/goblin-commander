using UnityEngine;
using Entitas;

public class GenerateCharacterSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext gameContext;

    public GenerateCharacterSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GenerateCharacterRequest.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGenerateCharacterRequest;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities)
    {
        foreach (GameEntity requestEntity in entities)
        {
            CreateTestCharacter(requestEntity.generateCharacterRequest);
        }
    }

    private void CreateTestCharacter(GenerateCharacterRequestComponent request)
    {
        GameEntity testCharacter = gameContext.CreateEntity();
        testCharacter.AddCharacterType(request.CharacterType);
        testCharacter.AddPosition(request.Position);
        testCharacter.AddFaction(request.Faction);
    }
}