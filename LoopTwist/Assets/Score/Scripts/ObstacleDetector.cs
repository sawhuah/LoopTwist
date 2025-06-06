using UnityEngine;
using UnityEngine.Events;

public class ObstacleDetector : MonoBehaviour
{
    public UnityEvent<int> Collided;
    [SerializeField] private ScoreCounter _scoreCounter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<ObstacleKiller>() != null)
        {
            Collided?.Invoke(_scoreCounter._scoreIncreasingFor1Obstacle);
        }
    }
}
