using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : ItemManager
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 10.0f); // ���� �ð��� ������ ������ �ı�
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
