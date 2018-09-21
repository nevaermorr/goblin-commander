using Entitas;

[Game]
public class CurrentEnemyComponent : IComponent
{
    public GameEntity Value;

    public static implicit operator GameEntity(CurrentEnemyComponent currentEnemyComponent)
    {
        return currentEnemyComponent.Value;
    }
}

public partial class GameEntity
{
    public bool HasCurrentEnemyInRange()
    {
        return this.hasCurrentEnemy
        && this.currentEnemy.Value.position.IsInRangeOf(
            this.position,
            this.attack.Range);
    }
}