using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateCharacterPrefabSystem : ReactiveSystem<GameEntity> {

    private GameContext gameContext;

    public InstantiateCharacterPrefabSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
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
                CharacterPrefabService.GetPrefabForType(entity.characterType)
            ) as GameObject;
            // TODO move linking to separate system.
            characterObject.Link(entity, gameContext);

            entity.AddGameObject(characterObject);
            PutInPosition(characterObject, entity);
        }
    }

    // TODO use trackedPosition / forcedPosition (or initPosition?) to differentiate.
    private void PutInPosition(GameObject characterObject, GameEntity entity)
    {
        if (entity.hasPosition)
        {
            characterObject.transform.position = entity.position;
        }
    }
}