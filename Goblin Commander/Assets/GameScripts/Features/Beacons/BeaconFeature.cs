using Entitas;

public class BeaconFeature : Feature
{
    public BeaconFeature(Contexts contexts)
    {
        Add(new PlaceBeaconSystem(contexts));
    }
}
