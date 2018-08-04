using Entitas;

public class CommonEntitiesBehaviourFeature : Feature
{
    public CommonEntitiesBehaviourFeature(Contexts contexts) : base ("Common entities behaviour")
    {
        Add(new CooldownSystem(contexts));
        Add(new DestroyEntitySystem(contexts));
    }
}