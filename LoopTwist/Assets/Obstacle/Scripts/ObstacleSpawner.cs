using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> Obstacles = new List<GameObject>();

    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _obstacleTypes;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private float _spawnDelay = 3.5f;
    [SerializeField] private float _timeToDestroy = 8f;

    [Space(5)]
    [SerializeField] private float _minXSpawnPos, _maxXSpawnPos;
    [SerializeField] private float _minYSpawnPos, _maxYSpawnPos;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged.AddListener(OnScoreChanged);
    }

    private void Awake()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while(true)
        {
            GameObject randomObstacle = _obstacleTypes[Random.Range(0, _obstacleTypes.Length)];
            GameObject obstacle = Instantiate(randomObstacle);

            obstacle.GetComponent<IObstacle>().Player = _player;
            obstacle.GetComponent<IObstacle>().ScoreCounter = _scoreCounter;
            PlaceAtRandomPosition(obstacle);
            Obstacles.Add(obstacle);
            StartCoroutine(DestroyObstacle(obstacle));

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void PlaceAtRandomPosition(GameObject obstacle)
    {
        obstacle.transform.position = new Vector2
            (Random.Range(_minXSpawnPos, _maxXSpawnPos), Random.Range(_minYSpawnPos, _maxYSpawnPos));
        obstacle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-90f, 90f)));
    }

    private IEnumerator DestroyObstacle(GameObject obstacle)
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(obstacle);
        Obstacles.Remove(obstacle);
    }

    private void OnScoreChanged(int value)
    {
        if(value % 5 == 0 && value != 0 && _spawnDelay > 1f)
        {
            _spawnDelay -= 0.4f;
        }
    }
}
