using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class EnergyRequireingRequestComponent : IComponent
{
    public Action OnSuccess;
    public Action OnFailure;
    public float EnergyCost;
}