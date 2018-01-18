using UnityEngine;
using Entitas;

[Game]
public class MoveComponent : IComponent
{
    public Vector2 Target;
    public float Speed;
}