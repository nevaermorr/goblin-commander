using Entitas;

public class MovementFeature : Feature
{
    public MovementFeature(Contexts contexts) : base ("Movement")
    {
        Add(new UpdatePositionSystem(contexts));
        Add(new CharacterMoveSystem(contexts));
    }
} 