using Entitas;

public class ControlFeature : Feature
{
    public ControlFeature(Contexts contexts) : base("Control")
    {
        Add(new InitializeBeaconSettingsSystem(contexts));
        Add(new SwitchBeaconActionSystem(contexts));
        Add(new PlaceBeaconSystem(contexts));
        Add(new BeaconSummonSystem(contexts));
        Add(new BeaconScareSystem(contexts));
    }
}
