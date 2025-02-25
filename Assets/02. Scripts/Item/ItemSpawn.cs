using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float spawnTime = 3f; // 아이템 생성 주기
    public float spawnDistance = 5f; //아이템 생성 위치를 플레이어에 맞춤
    public float fixedY = 0; //일단 y값 고정
    public Transform player;


    void Start()
    {
        // Coroutine을 사용하여 주기적으로 아이템 생성
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            float spawnX = player.position.x + spawnDistance;
            Vector2 spawnPosition = new Vector2(spawnX, fixedY);

            GameObject randomItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)]; // 랜덤하게 아이템프리팹 생성

            Instantiate(randomItem, spawnPosition, Quaternion.identity); // 아이템 생성
            Debug.Log("아이템을 생성합니다.");

            yield return new WaitForSeconds(spawnTime);
        }
    }

    
}
