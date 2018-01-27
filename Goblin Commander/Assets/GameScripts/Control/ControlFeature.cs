using Entitas;

public class ControlFeature : Feature
{
    public ControlFeature(Contexts contexts) : base("Control")
    {
        Add(new PlaceBeaconSystem(contexts));
        Add(new SummonCharacterToBeaconSystem(contexts));
    }
}
