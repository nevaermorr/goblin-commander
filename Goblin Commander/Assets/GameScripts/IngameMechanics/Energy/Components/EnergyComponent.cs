using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class MaxEnergyComponent : IComponent
{
    public float Value;

    public static implicit operator float(MaxEnergyComponent maxEnergyComponent)
    {
        return maxEnergyComponent.Value;
    }
}

[Game, Event(EventTarget.Any)]
public class CurrentEnergyComponent : IComponent
{
    public float Value;
    
    public static implicit operator float(CurrentEnergyComponent currentEnergyComponent)
    {
        return currentEnergyComponent.Value;
    }
}

public partial class GameEntity
{
    public void AddEnergy(float Energy)
    {
        this.AddMaxEnergy(Energy);
        this.AddCurrentEnergy(Energy);
    }
}