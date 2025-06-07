using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private float _movementSpeed = -2f;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged.AddListener(OnScoreChanged);
    }

    private void Update()
    {
        for(int i = 0; i < _obstacleSpawner.Obstacles.Count; i++)
        {
            if (_obstacleSpawner.Obstacles[i] != null)
            {
                _obstacleSpawner.Obstacles[i].transform.position +=
                    new Vector3(0f, _movementSpeed * Time.deltaTime, 0f);
            } 
        }
    }

    private void OnScoreChanged(int value)
    {
        if (value % 5 == 0 && value != 0 && _movementSpeed > -3.5f)
        {
            _movementSpeed -= 0.2f;
        }
    }
}
