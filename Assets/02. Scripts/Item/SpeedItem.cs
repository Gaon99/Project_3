using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemManager
{
    public override void DestroyAfterTime()
    {
        Invoke("DestoryObject", 1.0f);
    }

    public override void RunItem()
    {
        
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
