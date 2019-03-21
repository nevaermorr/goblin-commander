using Entitas;

public class LateEngineFeature : Feature {
    public LateEngineFeature(Contexts contexts) : base("Engine")
    {
        Add(new LateCommonMechanicsFeature(contexts));
    }
}