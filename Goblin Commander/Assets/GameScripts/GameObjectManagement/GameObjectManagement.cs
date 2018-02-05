using Entitas;

public class GameObjectManagement : Feature {
	public GameObjectManagement(Contexts contexts) : base("Game Object Management")
    {
        Add(new RemoveGameObjectSystem(contexts));
    }
}