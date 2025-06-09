using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameExitView : MonoBehaviour
{
    [SerializeField] private GameExit _gameExit;
    [SerializeField] private Animator _quitConfirmationScreenAnimator;
    [Space(5)]
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _cancelButton;

    private void OnEnable()
    {
        _gameExit.ExitButtonClicked.AddListener(OnExitButtonClicked);
        _gameExit.ExitCanceled.AddListener(OnExitCanceled);
    }

    private void Awake()
    {
        _quitConfirmationScreenAnimator.gameObject.SetActive(true);

        _quitButton.interactable = false;
        _cancelButton.interactable = false;
    }

    private void OnExitButtonClicked()
    {
        _quitConfirmationScreenAnimator.SetBool("IsAssigned", true);

        _quitButton.interactable = true;
        _cancelButton.interactable = true;

    }

    private void OnExitCanceled()
    { 
        _quitConfirmationScreenAnimator.SetBool("IsAssigned", false);

        _quitButton.interactable = false;
        _cancelButton.interactable = false;
    }
}
