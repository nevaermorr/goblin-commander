using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Any)]
public class DamageComponent : IComponent
{
    public float Value;
    public GameEntity Origin;
    public GameEntity Target;
}