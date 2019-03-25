using Entitas;

public class CommonMechanicsFeature : Feature
{
    public CommonMechanicsFeature(Contexts contexts) : base ("Common mechanics")
    {
        Add(new LinkGameObjectSystem(contexts));
        Add(new InitializeGameStateSystem(contexts));
        Add(new CooldownSystem(contexts));
    }
}