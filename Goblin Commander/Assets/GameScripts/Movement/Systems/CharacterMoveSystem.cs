using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CharacterMoveSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> characterEntities;
    public CharacterMoveSystem(Contexts contexts)
    {
        characterEntities = contexts.game.GetGroup(GameMatcher.CharacterController);
    }

    public void Execute()
    {
        foreach (var characterEntity in characterEntities.GetEntities()) {
            if (characterEntity.hasMoveTarget)
            {
                Move(characterEntity);
            }
        }
    }

    private void Move(GameEntity entity) {
        Vector2 path = entity.moveTarget.Value - entity.position.Value;
        float stepLength = entity.mobility.MovementSpeed * Time.deltaTime;
        if (stepLength >= path.magnitude)
        {
            MakeFinalStep(entity, path);
        }
        else {
            MakeStep(entity, path.normalized * stepLength);
        }
    }

    private void MakeFinalStep(GameEntity entity, Vector2 step)
    {
            MakeStep(entity, step);
            entity.RemoveMoveTarget();
    }

    private void MakeStep(GameEntity entity, Vector2 step)
    {
        entity.characterController.Value.Move(step);
    }
}