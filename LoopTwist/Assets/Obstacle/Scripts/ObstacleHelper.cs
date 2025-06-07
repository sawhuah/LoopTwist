using UnityEngine;

// summary
// A script for obstacle, which is increasing score when player touches it
// summary
public class ObstacleHelper : MonoBehaviour, IObstacle
{
    public Player Player { get; set; }
    public ScoreCounter ScoreCounter { get; set; }

    [SerializeField] private int _scoreIncreasing = 2;

    public void PerformAction()
    {
        for(int i = 0; i < _scoreIncreasing; i++)
        {
            ScoreCounter.IncreaseScore(1);
        }

        Destroy(gameObject);
    }
}
