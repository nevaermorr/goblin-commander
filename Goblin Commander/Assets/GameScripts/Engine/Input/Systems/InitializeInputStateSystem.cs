using Entitas;

public class InitializeInputStateSystem : IInitializeSystem
{
    private InputContext inputContext;
    public InitializeInputStateSystem(Contexts contexts)
    {
        inputContext = contexts.input;
    }

    public void Initialize()
    {
        InputEntity inputStateEntity = inputContext.CreateEntity();
        inputStateEntity.isInputState = true;
    }
}