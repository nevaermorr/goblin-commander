using Entitas;

public class EnergyFeature : Feature
{
    public EnergyFeature(Contexts contexts) : base("Energy")
    {
        Add(new InitEnergySystem(contexts));
    }
}
