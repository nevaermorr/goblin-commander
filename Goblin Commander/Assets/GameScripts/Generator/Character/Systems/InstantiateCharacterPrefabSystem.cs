using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class InstantiateCharacterPrefabSystem : ReactiveSystem<GameEntity> {

    public InstantiateCharacterPrefabSystem(Contexts contexts) : base(contexts.game) {}

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
        foreach (GameEntity characterEntity in entities)
        {
            InstantiateCharacterGameObject(characterEntity);
        }
    }

    private void InstantiateCharacterGameObject(GameEntity characterEntity)
    {
        CharacterType characterType = characterEntity.characterType.Value;
        CharacterSettings characterSettings = SettingsService.GetCharacterSettings(characterType);

        GameObject characterObject = Object.Instantiate(
            characterSettings.Prefab
        ) as GameObject;

        characterEntity.AddGameObject(characterObject);
        PutInPosition(characterObject, characterEntity);
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