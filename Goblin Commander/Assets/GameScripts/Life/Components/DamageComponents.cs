using Entitas;

public class DamageComponent : IComponent
{
    public float Value;
    public GameEntity Origin;
    public GameEntity Target;
}