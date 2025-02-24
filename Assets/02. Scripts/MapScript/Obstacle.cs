using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    public float highPosY = -1f;
    public float lowPosY = -2.7f;

    public float minGap = 6f;
    public float maxGap = 10f;

    [SerializeField] private float minDistance = 4f; // 최소 배치
    [SerializeField] private float maxDistance = 8f; // 최대 배치

    public Transform topObject;
    public Transform bottomObject;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float widthPadding = Random.Range(minDistance, maxDistance);
        float holeSize = Random.Range(minGap, maxGap) / 2f; //3~5f
        topObject.localPosition = new Vector3(0, holeSize);
        bottomObject.localPosition = new Vector3(0, -holeSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
