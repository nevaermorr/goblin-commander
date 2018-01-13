using Entitas;

public enum CharacterType
{
    goblin,
}

[Game]
public class CharacterComponent : IComponent
{
	public CharacterType Type;
}