using UnityEngine;
using Entitas;

[Game, Input]
public class PositionComponent : IComponent
{
	public Vector2 Value;
}