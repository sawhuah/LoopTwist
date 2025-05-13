using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    public UnityEvent<bool> PauseSwitched;

    [SerializeField] private Player _player;
    [SerializeField] private float _pauseDelay;
    [SerializeField] private bool _isCanPause = true;

    private void Start()
    {
        _player.Dead.AddListener(OnPlayerDead);
    }

    public void SwitchPause(bool value)
    {
        if(_isCanPause)
        {
            if (value)
            {
                PauseSwitched?.Invoke(true);
                StartCoroutine(Pause());
            }
            else
            {
                Resume();
            }
        } 
    }

    private IEnumerator Pause()
    {
        yield return new WaitForSeconds(_pauseDelay);
        Time.timeScale = 0f;
    }

    private void Resume()
    {       
        Time.timeScale = 1f;
        PauseSwitched?.Invoke(false);
    }

    private void OnPlayerDead() =>
        _isCanPause = false;
}
