using Entitas;

public class LifeFeature : Feature
{
    public LifeFeature(Contexts contexts) : base("Life")
    {
        Add(new DamageSystem(contexts));
    }
}