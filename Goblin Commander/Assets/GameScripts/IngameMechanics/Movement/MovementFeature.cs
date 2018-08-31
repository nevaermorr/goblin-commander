using Entitas;

public class MovementFeature : Feature
{
    public MovementFeature(Contexts contexts) : base ("Movement")
    {
        Add(new SetUpCharacterControllerSystem(contexts));
        Add(new UpdatePositionSystem(contexts));
        Add(new CharacterMoveSystem(contexts));
    }
} 