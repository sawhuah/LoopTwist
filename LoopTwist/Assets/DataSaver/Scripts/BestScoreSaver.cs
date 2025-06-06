using UnityEngine;

public class BestScoreSaver : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _player.Dead.AddListener(OnDead);
    }

    private void OnDead()
    {
        if (_scoreCounter.AllScore > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", _scoreCounter.AllScore);
            PlayerPrefs.Save();
        }
    }
}
