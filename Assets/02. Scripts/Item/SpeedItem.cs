using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemManager
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 5.0f);
    }

    public override void RunItem() //������ ��� ����
    {
        // �÷��̾� �ӵ�
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
