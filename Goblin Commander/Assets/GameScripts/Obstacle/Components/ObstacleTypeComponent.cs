using Entitas;

public enum ObstacleType
{
    crate,
}

[Game]
public class ObstacleTypeComponent : IComponent
{
	public ObstacleType Value;

    public static implicit operator ObstacleType(ObstacleTypeComponent obstacleTypeComponent)
    {
        return obstacleTypeComponent.Value;
    }
}