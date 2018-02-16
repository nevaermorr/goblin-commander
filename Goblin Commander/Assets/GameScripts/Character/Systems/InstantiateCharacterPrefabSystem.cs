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
            PutInPosition(characterObject, entity);
            ExtractCharacterComponentEntity(characterObject, entity);
            ExtractSpriteRendererComponent(characterObject, entity);
        }
    }

    private void ExtractCharacterComponentEntity(GameObject characterObject, GameEntity entity)
    {
        CharacterController characterController = characterObject.GetComponent<CharacterController>();
        if (characterController == null)
        {
            return;
        }
        entity.AddCharacterController(characterController);
    }
    
    private void ExtractSpriteRendererComponent(GameObject characterObject, GameEntity entity)
    {
        
        SpriteRenderer spriteRenderer = characterObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            return;
        }
        entity.AddSpriteRenderer(spriteRenderer);
    }

    private void PutInPosition(GameObject characterObject, GameEntity entity)
    {
        if (entity.hasPosition)
        {
            characterObject.transform.position = entity.position;
        }
    }
}