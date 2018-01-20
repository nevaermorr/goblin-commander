using Entitas;

public class ControlFeature : Feature
{
    public ControlFeature(Contexts contexts)
    {
        Add(new PlaceBeaconSystem(contexts));
        Add(new SummonCharacterToBeaconSystem(contexts));
    }
}
