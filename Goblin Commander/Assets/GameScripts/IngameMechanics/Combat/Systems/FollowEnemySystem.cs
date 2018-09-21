using Entitas;

public class FollowEnemySystem : IExecuteSystem
{
    private readonly GameContext gameContext;
    private readonly IGroup<GameEntity> enemyFollowers;

    public FollowEnemySystem(Contexts contexts)
    {
        gameContext = contexts.game;
        enemyFollowers = gameContext.GetGroup(GameMatcher.AllOf(
            GameMatcher.CurrentEnemy,
            GameMatcher.Mobility
        ));
    }
    public void Execute()
    {
        foreach(var enemyFollower in enemyFollowers)
        {
            if (enemyFollower.hasCurrentEnemy
                && enemyFollower.currentEnemy.Value.hasPosition
                && !enemyFollower.HasCurrentEnemyInRange())
            {
                enemyFollower.ReplaceMoveTarget(enemyFollower.currentEnemy.Value.position);
            }
        }
    }
}