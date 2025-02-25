using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemPrefab;
    public float minX = -6f; //������ ���� �ּ� ��ġ
    public float maxX = 6f; //������ ���� �ִ� ��ġ
    public float fixedY = 0f;
    public float minSpawn = 2f; //������ ���� �ּ� �ð�
    public float maxSpawn = 5f; //������ ���� �ּ� �ð�

    void Start()
    {
        Debug.Log("�������� �����߽��ϴ�.");
        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn)); // ù ������ ����
    }

    public void SpawnItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, fixedY); // X�� ���� Y�� ����

        Instantiate(itemPrefab, spawnPosition, Quaternion.identity); // ������ ����

        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn));
    }
}
