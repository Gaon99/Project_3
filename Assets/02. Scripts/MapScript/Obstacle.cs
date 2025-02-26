using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    // [SerializeField] private float highPosY = 2f;
    // [SerializeField] private float lowPosY = -2f;

    //[SerializeField] private float minGap = 6f; // 간격 사이 넓이 최소
    //[SerializeField] private float maxGap = 10f;// 간격 사이 넓이 최소

    [SerializeField] private float minDistance = 6f; // 최소 배치
    [SerializeField] private float maxDistance = 12f; // 최대 배치

    //public Transform topObject;
    public Transform bottomObject;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float widthPadding = Mathf.Round(Random.Range(minDistance, maxDistance));
        // float holeSize = Mathf.Round(Random.Range(minGap, maxGap)) / 2f; //3~5f, 0.5 간격
        // topObject.localPosition = new Vector3(0, holeSize);
        

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        
        transform.position = placePosition;

        return placePosition;
    }
}
