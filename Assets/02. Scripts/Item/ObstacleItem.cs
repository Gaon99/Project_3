using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : ItemManager
{
    public string obstacleTag = "Obstacle";
    public float destroyRadius = 2f; // ���ع� �ı� ����

    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 10.0f); // ���� �ð��� ������ ������ �ı�
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //�÷��̾ �������� ������
        {
            DestroyObstacles(); // ���ع� �ı�
            Destroy(gameObject); // ���� ������ �ı�
        }
    }
    private void DestroyObstacles()
    {
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, destroyRadius);

        foreach (Collider2D obstacle in obstacles)
        {
            if (obstacle.CompareTag(obstacleTag))
            {
                Destroy(obstacle.gameObject);  // ���ع� ����
            }
        }
    }

}
