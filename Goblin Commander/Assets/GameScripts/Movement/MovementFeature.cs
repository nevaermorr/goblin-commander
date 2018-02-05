using Entitas;

public class MovementFeature : Feature
{
    public MovementFeature(Contexts contexts) : base ("Movement")
    {
        Add(new MoveSystem(contexts));
        Add(new UpdatePositionSystem(contexts));
    }
} 