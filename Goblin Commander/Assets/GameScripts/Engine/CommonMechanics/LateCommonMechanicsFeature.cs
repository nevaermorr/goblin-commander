using Entitas;

public class LateCommonMechanicsFeature : Feature
{
    public LateCommonMechanicsFeature(Contexts contexts) : base ("Common mechanics")
    {
        Add(new DestroyEntitySystem(contexts));
        Add(new DestroyRequestSystem(contexts));
    }
}