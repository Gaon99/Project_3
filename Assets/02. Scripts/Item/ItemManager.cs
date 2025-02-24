using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemManager : MonoBehaviour
{
    public abstract void DestroyAfterTime();
    public abstract void RunItem();

    void Start()
    {
        DestroyAfterTime();
    }
}
