using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemManager : MonoBehaviour
{
    public abstract void DestroyAfterTime(); // �������ı�

    void Start()
    {
        DestroyAfterTime();
    }
}
