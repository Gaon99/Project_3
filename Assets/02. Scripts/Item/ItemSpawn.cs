using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject itemprefab;
    public float minX = -6f; // ������ ���� �ּ� �Ÿ�
    public float maxX = 6f; // ������ ���� �ִ� �Ÿ�
    public float fixedY = 0f; // y�� ����
    public float minSpawn = 2f; // ������ ���� �ּ� �ð�
    public float maxSpawn = 3f; // ������ ���� �ִ� �ð�

    private void Start()
    {
        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn)); // ù ������ ���� �ð� ����
    }

    private void SpawnItem()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 SpawnPosition = new Vector2(randomX, fixedY); // �����۰Ÿ� y�� ����

        Instantiate(itemprefab, SpawnPosition, Quaternion.identity);

        Invoke("SpawnItem", Random.Range(minSpawn, maxSpawn));

    }
}
