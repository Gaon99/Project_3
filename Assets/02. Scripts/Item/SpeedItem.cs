using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemManager
{
    public float speedUp = 5f; // 아이템을 먹었을 때 증가하는 속도

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
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.IncreaseSpeed(speedUp);
                Destroy(gameObject);
            }
        }
    }
}
