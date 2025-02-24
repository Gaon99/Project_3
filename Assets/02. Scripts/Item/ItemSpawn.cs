using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemprefab;
    public float minX = -6f; // 아이템 생성 최소 거리
    public float maxX = 6f; // 아이템 생성 최대 거리
    public float fixedY = 0f; // y는 고정
    public float minSpawn = 2f; // 아이템 생성 최소 시간
    public float maxSpawn = 3f; // 아이템 생성 최대 시간

    private void Start()
    {
        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn)); // 첫 아이템 생성 시간 랜덤
    }

    private void SpawnItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 SpawnPosition = new Vector2(randomX, fixedY); // 아이템거리 y는 고정

        Instantiate(itemprefab, SpawnPosition, Quaternion.identity);

        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn));

    }
}
