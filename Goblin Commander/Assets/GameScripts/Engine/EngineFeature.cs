using Entitas;

public class EngineFeature : Feature {
    public EngineFeature(Contexts contexts) : base("Engine")
    {
        Add(new InputFeature(contexts));
        Add(new CommonMechanicsFeature(contexts));
        Add(new ViewFeature(contexts));
    }
}