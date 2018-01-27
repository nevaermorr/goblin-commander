using Entitas;

public class CommonFeature : Feature
{
    public CommonFeature(Contexts contexts) : base ("Common")
    {
        Add(new CooldownSystem(contexts));
        Add(new DestroyEntitySystem(contexts));
    }
}