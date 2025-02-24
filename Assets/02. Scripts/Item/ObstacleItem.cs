using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleItem : ItemManager
{
    public override void DestroyAfterTime()
    {
        Invoke("DestroyObject", 10.0f); // 일정 시간이 지나면 아이템 파괴
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
