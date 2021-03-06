using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class MaxHealthComponent : IComponent
{
    public float Value;

    public static implicit operator float(MaxHealthComponent maxHealthComponent)
    {
        return maxHealthComponent.Value;
    }
}

[Game, Event(EventTarget.Any)]
public class CurrentHealthComponent : IComponent
{
    public float Value;
    
    public static implicit operator float(CurrentHealthComponent currentHealthComponent)
    {
        return currentHealthComponent.Value;
    }
}

public partial class GameEntity
{
    public void AddHealth(float health)
    {
        this.AddMaxHealth(health);
        this.AddCurrentHealth(health);
    }
}