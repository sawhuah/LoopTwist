using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject[] _obstacleTypes;
    [SerializeField] private float _spawnDelay = 2;
    [Space(5)]
    [SerializeField] private float _minXSpawnPos, _maxXSpawnPos;
    [SerializeField] private float _minYSpawnPos, _maxYSpawnPos;

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private IEnumerator SpawnObstacle()
    {
        while(true)
        {
            GameObject obstacle = Instantiate
            (_obstacleTypes[Random.Range(0, _obstacleTypes.Length)]);

            obstacle.transform.position = new Vector2(
                Random.Range(_minXSpawnPos, _maxXSpawnPos), Random.Range(_minYSpawnPos, _maxYSpawnPos));

            obstacle.transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, 90f));

            Destroy(obstacle, 15f);

            if(obstacle.GetComponent<IObstacle>() != null)
            {
                obstacle.GetComponent<IObstacle>().Player = _player;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }  
    }
}
