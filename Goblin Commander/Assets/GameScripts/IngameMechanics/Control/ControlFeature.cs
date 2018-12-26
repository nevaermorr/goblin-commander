using Entitas;

public class ControlFeature : Feature
{
    public ControlFeature(Contexts contexts) : base("Control")
    {
        Add(new SwitchBeaconActionSystem(contexts));
        Add(new BeaconRallySystem(contexts));
        Add(new BeaconScareSystem(contexts));
        Add(new BeaconSummonSystem(contexts));
    }
}
