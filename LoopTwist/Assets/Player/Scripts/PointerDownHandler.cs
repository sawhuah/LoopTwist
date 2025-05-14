using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerDownHandler : MonoBehaviour
{
    public UnityEvent Pressed;
    private bool hasFired = false;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasFired && !IsPointerOverUI())
        {
            hasFired = true;
            Pressed?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            hasFired = false;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !hasFired && !IsPointerOverUI(touch))
            {
                hasFired = true;
                Pressed?.Invoke();
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                hasFired = false;
            }
        }
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
    }

    private bool IsPointerOverUI(Touch touch)
    {
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(touch.fingerId);
    }
}
