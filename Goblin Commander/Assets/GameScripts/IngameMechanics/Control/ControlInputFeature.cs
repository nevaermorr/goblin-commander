using Entitas;

public class ControlInputFeature : Feature
{
    public ControlInputFeature(Contexts contexts) : base("Control")
    {
        Add(new PlaceBeaconSystem(contexts));
    }
}
