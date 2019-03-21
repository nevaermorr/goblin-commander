using Entitas;

public class LateCommonMechanicsFeature : Feature
{
    public LateCommonMechanicsFeature(Contexts contexts) : base ("Common mechanics")
    {
        Add(new LinkGameObjectSystem(contexts));
        Add(new DestroyEntitySystem(contexts));
        Add(new DestroyRequestSystem(contexts));
    }
}