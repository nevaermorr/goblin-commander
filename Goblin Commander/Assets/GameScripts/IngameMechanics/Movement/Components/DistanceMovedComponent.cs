using UnityEngine;
using Entitas;

[Game]
public class DistanceMovedComponent : IComponent
{
    public Vector2 Value;

	public static implicit operator Vector2(DistanceMovedComponent distanceMovedComponent)
	{
		return distanceMovedComponent.Value;
	}
}