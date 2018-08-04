using Entitas;

public class GameElementsCreationFeature : Feature {
    public GameElementsCreationFeature(Contexts contexts) : base("Game elements generation")
    {
        Add(new CharacterCreationFeature(contexts));
    }
}