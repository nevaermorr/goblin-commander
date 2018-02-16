using Entitas;

public class ViewFeature : Feature
{
    public ViewFeature(Contexts contexts) : base ("View")
    {
        Add(new OrderSpritesSystem(contexts));
    }
}