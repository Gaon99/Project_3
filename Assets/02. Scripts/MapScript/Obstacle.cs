using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Obstacle : MonoBehaviour
{
    [SerializeField] private int lifeTime = 10;
    public void Awake()
    {
        Destroy(gameObject, lifeTime);
    }

}
