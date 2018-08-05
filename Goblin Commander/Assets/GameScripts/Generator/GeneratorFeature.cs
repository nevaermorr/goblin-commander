using Entitas;

public class GeneratorFeature : Feature {
    public GeneratorFeature(Contexts contexts) : base("Game elements generation")
    {
        Add(new CharacterCreationFeature(contexts));
        Add(new ObstacleCreationFeature(contexts));
    }
}