using Entitas;

public class AnimationsFeature : Feature
{
    public AnimationsFeature(Contexts contexts) : base("Animations")
    {
        Add(new SetUpAnimatorSystem(contexts));
        Add(new AnimateMovementSystem(contexts));
        Add(new AnimateAttackSystem(contexts));
        Add(new AnimateSummonSystem(contexts));
    }
}