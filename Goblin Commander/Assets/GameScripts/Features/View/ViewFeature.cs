using Entitas;

public class ViewFeature : Feature {
	public ViewFeature(Contexts contexts) : base("View")
    {
        Add(new AddGameObjectSystem(contexts));
        Add(new RemoveGameObjectSystem(contexts));
        Add(new UpdatePositionSystem(contexts));
        Add(new UpdateSpriteSystem(contexts));
    }
}