using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateCharacterPrefabSystem : ReactiveSystem<GameEntity> {

    private GameContext context;

    public InstantiateCharacterPrefabSystem(Contexts contexts) : base(contexts.game)
    {
        context = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CharacterType);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterType;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            GameObject characterObject = Object.Instantiate(
                CharacterPrefabService.GetCharacterPrefabForType(entity.characterType)
            ) as GameObject;
            characterObject.Link(entity, context);
            entity.AddGameObject(characterObject);
        }
    }
}