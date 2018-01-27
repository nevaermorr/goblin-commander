using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class AttackCurrentEnemySystem : IExecuteSystem
{
    private readonly GameContext gameContext;
    private readonly IGroup<GameEntity> charactersGroup;
    public AttackCurrentEnemySystem(Contexts contexts)
    {
        gameContext = contexts.game;
        charactersGroup = gameContext.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.CurrentEnemy,
                GameMatcher.Attack,
                GameMatcher.Position
            )
        );
    }

    public void Execute()
    {
        foreach (var characterEntity in charactersGroup.GetEntities())
        {
            if (characterEntity.currentEnemy.Value.position.IsInRangeOf(
                characterEntity.position,
                characterEntity.attack.Range))
            {
                characterEntity.CancelMovement();
                characterEntity.attack.DeliverTo(characterEntity.currentEnemy);
            }
        }
    }
}