using Entitas;
using UnityEngine;

[Game]
public class GameObjectComponent : IComponent
{
	public GameObject Value;

	public static implicit operator GameObject(GameObjectComponent gameObjectComponent)
	{
		return gameObjectComponent.Value;
	}
}