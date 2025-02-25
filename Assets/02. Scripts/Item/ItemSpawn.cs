using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject[] itemPrefabs;
    public float spawnTime = 3f; // ������ ���� �ֱ�
    public float spawnDistance = 5f; //������ ���� ��ġ�� �÷��̾ ����
    public float fixedY = 0; //�ϴ� y�� ����
    public Transform player;


    void Start()
    {
        // Coroutine�� ����Ͽ� �ֱ������� ������ ����
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        while (true)
        {
            float spawnX = player.position.x + spawnDistance;
            Vector2 spawnPosition = new Vector2(spawnX, fixedY);

            GameObject randomItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)]; // �����ϰ� ������������ ����

            Instantiate(randomItem, spawnPosition, Quaternion.identity); // ������ ����
            Debug.Log("�������� �����մϴ�.");

            yield return new WaitForSeconds(spawnTime);
        }
    }

    
}
