using Entitas;

public class IngameMechacnicsFeature : Feature {
    public IngameMechacnicsFeature(Contexts contexts) : base("Ingame mechanics")
    {
        Add(new CharacterControlFeature(contexts));
        Add(new CombatFeature(contexts));
        Add(new MovementFeature(contexts));
        Add(new LifeFeature(contexts));
    }
}