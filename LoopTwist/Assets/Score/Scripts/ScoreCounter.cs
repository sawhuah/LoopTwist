using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public UnityEvent<int> ScoreChanged;
    public int AllScore { get; private set; }
    public int _scoreIncreasingFor1Obstacle { get; private set; } = 1;

    [SerializeField] private ObstacleDetector _obstacleDetector;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        SetScore(0);
        _obstacleDetector.Collided.AddListener(IncreaseScore);
    }

    public void IncreaseScore(int amount)
    {
        if(_player.IsDead == false)
        {
            AllScore += amount;
            ScoreChanged?.Invoke(AllScore);
        }  
    }

    private void SetScore(int value)
    {
        AllScore = value;
        ScoreChanged?.Invoke(AllScore);
    }
}
