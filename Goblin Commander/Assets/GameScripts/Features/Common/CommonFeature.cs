using Entitas;

public class CommonFeature : Feature
{
    public CommonFeature(Contexts contexts) : base ("Common")
    {
        Add(new DestroyEntitySystem(contexts));
    }
}