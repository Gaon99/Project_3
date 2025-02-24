using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : ItemManager
{
    public string obstacleTag = "Obstacle";
    public float destroyRadius = 2f; // 방해물 파괴 범위

    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 10.0f); // 일정 시간이 지나면 아이템 파괴
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //플레이어가 아이템을 먹으면
        {
            DestroyObstacles(); // 방해물 파괴
            Destroy(gameObject); // 먹은 아이템 파괴
        }
    }
    private void DestroyObstacles()
    {
        Collider2D[] obstacles = Physics2D.OverlapCircleAll(transform.position, destroyRadius);

        foreach (Collider2D obstacle in obstacles)
        {
            if (obstacle.CompareTag(obstacleTag))
            {
                Destroy(obstacle.gameObject);  // 방해물 삭제
            }
        }
    }

}
