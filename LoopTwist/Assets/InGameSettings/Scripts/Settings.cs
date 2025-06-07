using UnityEngine;
using UnityEngine.Events;

public class Settings : MonoBehaviour
{
    public UnityEvent Opened;
    public UnityEvent Closed;

    private bool _isOpened;

    private void Awake()
    {
        Close();
    }

    public void Switch()
    {
        if(_isOpened)
            Close();
        else
            Open();
    }

    public void Open()
    {
        _isOpened = true;
        Opened?.Invoke(); 
    }

    public void Close()
    {
        _isOpened = false;
        Closed?.Invoke();
    }
}
