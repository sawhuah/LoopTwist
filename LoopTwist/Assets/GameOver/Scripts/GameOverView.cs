using UnityEngine;
using System.Collections;
using TMPro;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Animator _gameOverScreenAnimator;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _scoreLabel;
    [SerializeField] private float _assigningDelay;

    private void Awake()
    {
        _gameOverScreen.SetActive(false);
        _player.Dead.AddListener(OnPlayerDead);
    }

    private void OnPlayerDead()
    {
        StartCoroutine(AssignGameOverScreen());
        _scoreLabel.text = "SCORE:" + _scoreCounter.AllScore.ToString();
    }

    private IEnumerator AssignGameOverScreen()
    {
        yield return new WaitForSeconds(_assigningDelay);
        _gameOverScreen.SetActive(true);
        _gameOverScreenAnimator.SetBool("IsAssigned", true);
    }
}
