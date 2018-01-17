using Entitas;

public class DestructorFeature : Feature
{
    public DestructorFeature(Contexts contexts)
    {
        Add(new DestroyEntitySystem(contexts));
    }
}