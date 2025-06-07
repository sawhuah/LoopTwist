using UnityEngine;
using UnityEngine.Events;

public class GameExit : MonoBehaviour
{
    public UnityEvent ExitButtonClicked;
    public UnityEvent ExitCanceled;

    public void Exit()
    {
        ExitButtonClicked?.Invoke();
    }

    public void CancelExit()
    {
        ExitCanceled.Invoke();
    }
}
