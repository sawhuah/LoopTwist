using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class PauseView : MonoBehaviour
{
    [SerializeField] private PauseHandler _handler;
    [SerializeField] private GameObject _pauseScreen;
    [SerializeField] private Animator _pauseScreenAnimator;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Start()
    {
        _handler.PauseSwitched.AddListener(OnPauseSwitched);
        _pauseScreen.SetActive(false);
    }

    private void OnPauseSwitched(bool isPaused)
    {
        _pauseScreen.SetActive(isPaused);
        _pauseScreenAnimator.SetBool("IsAssigned", isPaused);
        _pauseButton.SetActive(!isPaused);

        _scoreLabel.text = _scoreCounter.AllScore.ToString();
    }
}
