using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemManager
{
    public float speedUp = 5f; // �������� �Ծ��� �� �����ϴ� �ӵ�

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
