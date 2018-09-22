using Entitas;

public class CommonMechanicsFeature : Feature
{
    public CommonMechanicsFeature(Contexts contexts) : base ("Common mechanics")
    {
        Add(new CooldownSystem(contexts));
        Add(new DestroyEntitySystem(contexts));
    }
}