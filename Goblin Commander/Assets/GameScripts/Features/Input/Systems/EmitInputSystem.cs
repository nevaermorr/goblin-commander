using UnityEngine;
using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem {
	private readonly InputContext context;
    private InputEntity leftMouseEntity;
    private InputEntity rightMouseEntity;

    public EmitInputSystem(Contexts contexts) {
        context = contexts.input;
    }

    public void Initialize()
    {
        InitLeftMouse();
        InitRightMouse();
    }

    private void InitLeftMouse()
    {
        context.isMouseLeft = true;
        leftMouseEntity = context.mouseLeftEntity;
    }

    private void InitRightMouse()
    {
        context.isMouseRight = true;
        rightMouseEntity = context.mouseRightEntity;
    }

    public void Execute()
    {
        SetLeftMouseState();
        SetRightMouseState();
    }

    private void SetLeftMouseState()
    {
        SetMouseState(leftMouseEntity, 0);
    }

    private void SetRightMouseState()
    {
        SetMouseState(rightMouseEntity, 1);
    }

    private void SetMouseState(InputEntity mouseButtonEntity, int mouseButtonIndex)
    {
        mouseButtonEntity.ReplacePosition(
            Camera.main.ScreenToWorldPoint(Input.mousePosition)
        );
        mouseButtonEntity.isMouseDown = Input.GetMouseButton(mouseButtonIndex);
        mouseButtonEntity.isMousePressed = Input.GetMouseButtonDown(mouseButtonIndex);
        mouseButtonEntity.isMouseReleased = Input.GetMouseButtonUp(mouseButtonIndex);
    }
}