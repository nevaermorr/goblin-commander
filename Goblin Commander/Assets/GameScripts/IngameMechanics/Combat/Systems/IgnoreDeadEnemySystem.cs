using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class IgnoreDeadEnemySystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext gameContext;
    private readonly IGroup<GameEntity> charactersGroup;
    public IgnoreDeadEnemySystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
        charactersGroup = gameContext.GetGroup(GameMatcher.CharacterType);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ToDestroy);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterType;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity destroyedEntity in entities)
        {
            foreach (GameEntity characterEntity in charactersGroup.GetEntities())
            {
                if (characterEntity.hasCurrentEnemy
                    && characterEntity.currentEnemy.Value == destroyedEntity)
                {
                    characterEntity.RemoveCurrentEnemy();
                }
            }
        }
    }
}