using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class SetUpCharacterControllerSystem : ReactiveSystem<GameEntity>
{
    public SetUpCharacterControllerSystem(Contexts contexts) : base(contexts.game) { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameObject.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasGameObject && !entity.hasCharacterController;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            ExtractCharacterController(entity);
        }
    }
    private void ExtractCharacterController(GameEntity entity)
    {
        CharacterController characterController = entity.gameObject.Value.GetComponent<CharacterController>();
        if (characterController != null)
        {
            entity.AddCharacterController(characterController);
        }
    }
}