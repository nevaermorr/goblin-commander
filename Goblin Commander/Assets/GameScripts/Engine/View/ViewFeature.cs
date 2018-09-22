using Entitas;

public class ViewFeature : Feature
{
    public ViewFeature(Contexts contexts) : base ("View")
    {
        Add(new SetUpSpriteRendererSystem(contexts));
        Add(new SetUpOrientationSystem(contexts));
        Add(new OrientateSpriteSystem(contexts));
        Add(new OrderSpritesSystem(contexts));
    }
}