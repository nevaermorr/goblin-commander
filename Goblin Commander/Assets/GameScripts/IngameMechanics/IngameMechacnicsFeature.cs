using Entitas;

public class IngameMechacnicsFeature : Feature {
    public IngameMechacnicsFeature(Contexts contexts) : base("Ingame mechanics")
    {
        Add(new ControlInputFeature(contexts));
        Add(new EnergyFeature(contexts));
        Add(new ControlFeature(contexts));
        Add(new CombatFeature(contexts));
        Add(new MovementFeature(contexts));
        Add(new LifeFeature(contexts));
        Add(new CombatCleanupFeature(contexts));
    }
}