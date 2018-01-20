using UnityEngine;
using Entitas;

[Game, Input]
public class PositionComponent : IComponent
{
	public Vector2 Value;

	public bool IsInRangeOf(Vector2 targetPosition, float range)
	{
		return Vector2.Distance(Value, targetPosition) <= range;
	}

	public static implicit operator Vector2(PositionComponent positionComponent)
	{
		return positionComponent.Value;
	}

	public static implicit operator Vector3(PositionComponent positionComponent)
	{
		return (Vector3) positionComponent.Value;
	}
}