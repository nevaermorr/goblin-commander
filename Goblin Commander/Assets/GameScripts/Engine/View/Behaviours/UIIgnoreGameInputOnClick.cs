using UnityEngine;
using UnityEngine.EventSystems;
using Entitas;

public class UIIgnoreGameInputOnClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        InputService.IgnoreInputForCurrentFrame();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        InputService.UnignoreInputForCurrentFrame();
    }
}