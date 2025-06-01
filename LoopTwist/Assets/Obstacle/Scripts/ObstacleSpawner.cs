using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> Obstacles { get; private set; } = new List<GameObject>();
    public int ObstaclesAmount { get; private set; } = 8;

    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _obstacleTypes;
    [SerializeField] private float _spawnDelay = 3.5f;
    [SerializeField] private float _timeToRespawn = 9f;

    [Space(5)]
    [SerializeField] private float _minXSpawnPos, _maxXSpawnPos;
    [SerializeField] private float _minYSpawnPos, _maxYSpawnPos;

    private void Awake()
    {
        for(int i = 0; i < ObstaclesAmount; i++)
        {
            GameObject randomObstacle = _obstacleTypes[Random.Range(0, _obstacleTypes.Length)];
            GameObject obstacle = Instantiate(randomObstacle);
            obstacle.GetComponent<IObstacle>().Player = _player;
            Obstacles.Add(obstacle);

            obstacle.SetActive(false);
            obstacle.transform.position = new Vector2
                (Random.Range(_minXSpawnPos, _maxXSpawnPos), Random.Range(_minYSpawnPos, _maxYSpawnPos));
            obstacle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-90f, 90f)));
        }

        StartCoroutine(EnableObstacles());
    }

    private IEnumerator EnableObstacles()
    {
        while (true)
        {
            for(int i = 0; i < ObstaclesAmount; i++)
            {
                if(Obstacles[i].activeInHierarchy == false)
                {
                    Obstacles[i].SetActive(true);
                    StartCoroutine(RespawnObstacle(Obstacles[i]));
                }

                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }

    private IEnumerator RespawnObstacle(GameObject obstacle)
    {
        while(true)
        {
            yield return new WaitForSeconds(_timeToRespawn);

            obstacle.transform.position = new Vector2
                    (Random.Range(_minXSpawnPos, _maxXSpawnPos), Random.Range(_minYSpawnPos, _maxYSpawnPos));
            obstacle.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Random.Range(-90f, 90f)));
        }
    }
}
