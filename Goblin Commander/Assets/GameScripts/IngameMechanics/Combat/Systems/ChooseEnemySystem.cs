using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class ChooseEnemySystem : IExecuteSystem
{
    private readonly GameContext gameContext;
    private readonly IGroup<GameEntity> charactersGroup;
    public ChooseEnemySystem(Contexts contexts)
    {
        gameContext = contexts.game;
        charactersGroup = gameContext.GetGroup(GameMatcher
            .AllOf(
                GameMatcher.CharacterType,
                GameMatcher.SightRange,
                GameMatcher.Faction
            ).NoneOf(
                GameMatcher.CurrentEnemy
            )
        );
    }

    public void Execute()
    {
        foreach (var characterEntity in charactersGroup.GetEntities())
        {
            GameEntity chosenEnemy = ChooseEnemyFor(characterEntity);
            characterEntity.UpdateCurrentEnemy(chosenEnemy);
        }
    }

    private GameEntity ChooseEnemyFor(GameEntity characterEntity)
    {
        GameEntity chosenEnemyEntity = null;
        foreach (var enemyEntity in characterEntity.GetEnemiesInSight())
        {
            chosenEnemyEntity = characterEntity.GetPreferredEnemy(chosenEnemyEntity, enemyEntity);
        }
        return chosenEnemyEntity;
    }
}

public partial class GameEntity
{
    public List<GameEntity> GetEnemiesInSight()
    {
        List<GameEntity> enemiesInSight = new List<GameEntity>();
        foreach (var entityInSight in GetEntitiesInSight())
        {
            if (entityInSight.hasCharacterType
                && IsHostileTowards(entityInSight))
            {
                enemiesInSight.Add(entityInSight);
            }
        }
        return enemiesInSight;
    }

    public GameEntity GetPreferredEnemy(GameEntity firstEnemy, GameEntity secondEnemy)
    {

        if (firstEnemy == null)
        {
            return secondEnemy;
        }
        if (secondEnemy == null)
        {
            return firstEnemy;
        }

        Debug.Assert(this.hasPosition && firstEnemy.hasPosition && secondEnemy.hasPosition);

        if (Vector2.Distance(this.position, firstEnemy.position) 
            < Vector2.Distance(this.position, secondEnemy.position))
        {
            return firstEnemy;
        }
        else {
            return secondEnemy;
        }
    }

    public void UpdateCurrentEnemy(GameEntity enemyEntity)
    {
        if (enemyEntity != null)
        {
            ReplaceCurrentEnemy(enemyEntity);
        }
        else if (this.hasCurrentEnemy)
        {
            RemoveCurrentEnemy();
        }
    }
}