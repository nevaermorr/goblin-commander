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

public partial class GameEntity
{
	public void CancelMovement()
	{
        if (this.hasMoveTarget)
        {
            this.RemoveMoveTarget();
        }
	}
}