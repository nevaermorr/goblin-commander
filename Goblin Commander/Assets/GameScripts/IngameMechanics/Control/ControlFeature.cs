using Entitas;

public class CharacterControlFeature : Feature
{
    public CharacterControlFeature(Contexts contexts) : base("Control")
    {
        Add(new InitializeBeaconSettingsSystem(contexts));
        Add(new PlaceBeaconSystem(contexts));
        Add(new SummonCharacterToBeaconSystem(contexts));
    }
}
