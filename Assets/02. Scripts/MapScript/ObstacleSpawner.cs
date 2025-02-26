using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    [SerializeField] private float minspawnRate = 3f;
    [SerializeField] private float maxSpawnRate = 5f;
    [SerializeField] private float spawnDistance = 12f;

    public Transform player;

    // private GameObject lastSpawnedGroup;

    private void Start()
    {
        StartCoroutine(SpawnObstacleGroup());
    }


    IEnumerator SpawnObstacleGroup()
    {
        while (true)
        {
            float spawnRate = Random.Range(minspawnRate, maxSpawnRate + 1);
            yield return new WaitForSeconds(spawnRate);

            float spawnX = player.position.x + spawnDistance;
            Vector2 spawnP = new Vector2(spawnX, 0);
            GameObject obstacle = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
            Instantiate(obstacle, spawnP, Quaternion.identity);
            
        }
       
        
    }
}

