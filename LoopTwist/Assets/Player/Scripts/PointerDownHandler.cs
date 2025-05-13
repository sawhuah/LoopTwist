using UnityEngine;
using UnityEngine.Events;

public class PointerDownHandler : MonoBehaviour
{
    public UnityEvent Pressed;

    private bool hasFired = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasFired)
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

            if (touch.phase == TouchPhase.Began && !hasFired)
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
}