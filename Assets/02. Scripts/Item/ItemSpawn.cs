using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public float minX = -6f; //아이템 생성 최소 위치
    public float maxX = 6f; //아이템 생성 최대 위치
    public float fixedY = 0f;
    public float minSpawn = 2f; //아이템 생성 최소 시간
    public float maxSpawn = 5f; //아이템 생성 최소 시간

    void Start()
    {
        Debug.Log("아이템을 생성했습니다.");
        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn)); // 첫 아이템 생성
    }

    public void SpawnItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, fixedY); // X는 랜덤 Y는 고정

        Instantiate(itemPrefab, spawnPosition, Quaternion.identity); // 아이템 생성

        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn));
    }
}
