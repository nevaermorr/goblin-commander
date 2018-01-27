using Entitas;

public enum CharacterType
{
    goblin,
}

[Game]
public class CharacterTypeComponent : IComponent
{
	public CharacterType Value;

    public static implicit operator CharacterType(CharacterTypeComponent characterTypeComponent)
    {
        return characterTypeComponent.Value;
    }
}