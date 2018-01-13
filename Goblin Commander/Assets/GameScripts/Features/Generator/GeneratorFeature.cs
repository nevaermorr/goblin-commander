using Entitas;

public class GeneratorFeature : Feature {
	public GeneratorFeature(Contexts contexts) : base("Generator")
    {
        Add(new GenerateCharacterSystem(contexts));
    }
}