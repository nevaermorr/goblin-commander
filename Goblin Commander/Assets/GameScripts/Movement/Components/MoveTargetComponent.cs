using UnityEngine;
using Entitas;

[Game]
public class MoveTargetComponent : IComponent
{
    public Vector2 Value;

	public static implicit operator Vector2(MoveTargetComponent moveTargetComponent)
	{
		return moveTargetComponent.Value;
	}
}