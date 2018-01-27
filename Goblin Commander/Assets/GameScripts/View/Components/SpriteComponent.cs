using UnityEngine;
using Entitas;

public class SpriteComponent : IComponent
{
	public Sprite Value;

	public static implicit operator Sprite(SpriteComponent spriteComponent)
	{
		return spriteComponent.Value;
	}
}