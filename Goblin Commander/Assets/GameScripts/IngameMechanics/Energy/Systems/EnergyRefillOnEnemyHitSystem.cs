using System.Collections.Generic;
using Entitas;

public class EnergyRefillOnEnemyHitSystem : ReactiveSystem<GameEntity>
{
    GameContext gameContext;
    public EnergyRefillOnEnemyHitSystem(Contexts contexts) : base(contexts.game)
    {
        gameContext = contexts.game;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Damage.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.IsEnemy;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity enemyEntity in entities)
        {
            RecoverEnergy();
        }
    }

    private void RecoverEnergy()
    {
        gameContext.gameStateEntity.ReplaceCurrentEnergy(
            gameContext.gameStateEntity.currentEnergy
            + gameContext.settingsEntity.globalSettings.Value.EnergyRecoveryAmountOnEnemyHit
        );
    }
}