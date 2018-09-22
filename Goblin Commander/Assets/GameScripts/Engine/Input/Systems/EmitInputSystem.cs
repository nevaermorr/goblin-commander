using UnityEngine;
using Entitas;

public class EmitInputSystem : IInitializeSystem, IExecuteSystem {

    private const int LEFT_MOUSE_BUTTON_INDEX = 0;
    private const int RIGHT_MOUSE_BUTTON_INDEX = 1;

	private readonly InputContext inputContext;
    private InputEntity leftMouseEntity;
    private InputEntity rightMouseEntity;

    public EmitInputSystem(Contexts contexts) {
        inputContext = contexts.input;
    }

    public void Initialize()
    {
        InitLeftMouse();
        InitRightMouse();
    }

    private void InitLeftMouse()
    {
        inputContext.isMouseLeft = true;
        leftMouseEntity = inputContext.mouseLeftEntity;
    }

    private void InitRightMouse()
    {
        inputContext.isMouseRight = true;
        rightMouseEntity = inputContext.mouseRightEntity;
    }

    public void Execute()
    {
        if (inputContext.inputStateEntity.isIgnoreInput)
        {
            return;
        }
        SetLeftMouseState();
        SetRightMouseState();
    }

    private void SetLeftMouseState()
    {
        SetMouseState(leftMouseEntity, LEFT_MOUSE_BUTTON_INDEX);
    }

    private void SetRightMouseState()
    {
        SetMouseState(rightMouseEntity, RIGHT_MOUSE_BUTTON_INDEX);
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