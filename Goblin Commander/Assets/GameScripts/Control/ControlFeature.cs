using Entitas;

public class CharacterControlFeature : Feature
{
    public CharacterControlFeature(Contexts contexts) : base("Control")
    {
        Add(new PlaceBeaconSystem(contexts));
        Add(new SummonCharacterToBeaconSystem(contexts));
    }
}
