using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerDownHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent<PointerEventData> Clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        Clicked?.Invoke(eventData);
        
    }
}
