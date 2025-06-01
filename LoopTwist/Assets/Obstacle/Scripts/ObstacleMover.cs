using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner _obstacleSpawner;
    [SerializeField] private float _movementSpeed = -2f;

    private void Update()
    {
        if(_obstacleSpawner.Obstacles.Count == _obstacleSpawner.ObstaclesAmount)
        {
            for(int i = 0; i < _obstacleSpawner.Obstacles.Count; i++)
            {
                if(_obstacleSpawner.Obstacles[i].activeInHierarchy)
                {
                    _obstacleSpawner.Obstacles[i].transform.position += 
                        new Vector3(0f, _movementSpeed * Time.deltaTime, 0f);
                }
            }
        }
    }
}
