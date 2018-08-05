using Entitas;

public class ObstacleCreationFeature : Feature
{
	public ObstacleCreationFeature(Contexts contexts) : base("Character")
    {
        Add(new GenerateObstacleSystem(contexts));
        Add(new InstantiateObstaclePrefabSystem(contexts));
    }
}