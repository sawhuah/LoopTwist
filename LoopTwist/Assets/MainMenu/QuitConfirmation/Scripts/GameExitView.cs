using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameExitView : MonoBehaviour
{
    [SerializeField] private GameExit _gameExit;
    [SerializeField] private Animator _quitConfirmationScreenAnimator;

    private void OnEnable()
    {
        _gameExit.ExitButtonClicked.AddListener(OnExitButtonClicked);
        _gameExit.ExitCanceled.AddListener(OnExitCanceled);
    }

    private void Awake()
    {
        _quitConfirmationScreenAnimator.gameObject.SetActive(true);
    }

    private void OnExitButtonClicked()
    {
        _quitConfirmationScreenAnimator.SetBool("IsAssigned", true);
    }

    private void OnExitCanceled()
    { 
        _quitConfirmationScreenAnimator.SetBool("IsAssigned", false);
    }
}
