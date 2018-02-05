using Entitas;

public class CharacterFeature : Feature
{
	public CharacterFeature(Contexts contexts) : base("Character")
    {
        Add(new GenerateCharacterSystem(contexts));
        Add(new InstantiateCharacterPrefabSystem(contexts));
    }
}