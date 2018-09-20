using Entitas;

public class AnimationsFeature : Feature
{
    public AnimationsFeature(Contexts contexts) : base("Animations")
    {
        Add(new SetUpAnimatorSystem(contexts));
        Add(new AnimateWalk(contexts));
    }
}