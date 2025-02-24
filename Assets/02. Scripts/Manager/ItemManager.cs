using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemManager : MonoBehaviour
{
    public abstract void DestroyAfterTime(); // 아이템파괴

    void Start()
    {
        DestroyAfterTime();
    }
}
