using Entitas;

public class CurrentEnemyComponent : IComponent
{
    public GameEntity Value;

    public static implicit operator GameEntity(CurrentEnemyComponent currentEnemyComponent)
    {
        return currentEnemyComponent.Value;
    }
}