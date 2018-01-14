using UnityEngine;
using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem {
	private readonly InputContext context;
    private InputEntity leftMouseEntity;

    public EmitInputSystem(Contexts contexts) {
        context = contexts.input;
    }

    public void Initialize()
    {
        context.isMouseLeft = true;
        leftMouseEntity = context.mouseLeftEntity;
    }

    public void Execute()
    {
        leftMouseEntity.ReplacePosition(
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );
        leftMouseEntity.isMouseDown = Input.GetMouseButton(0);
        leftMouseEntity.isMousePressed = Input.GetMouseButtonDown(0);
        leftMouseEntity.isMouseReleased = Input.GetMouseButtonUp(0);
    }
}