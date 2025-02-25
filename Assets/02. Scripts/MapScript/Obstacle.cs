using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float highPosY = -1f;
    [SerializeField] private float lowPosY = -2.7f;

    [SerializeField] private float minGap = 6f; // ���� ���� ���� �ּ�
    [SerializeField] private float maxGap = 10f;// ���� ���� ���� �ּ�

    [SerializeField] private float minDistance = 4f; // �ּ� ��ġ
    [SerializeField] private float maxDistance = 8f; // �ִ� ��ġ

    [SerializeField] private float roundSize = 0.5f; // �ݿø� ��. �� �� ��Ȯ�� �߸�����

    public Transform topObject;
    public Transform bottomObject;

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float widthPadding = Random.Range(minDistance, maxDistance);
        float holeSize = Mathf.Round(Random.Range(minGap, maxGap)) / 2f; //3~5f
        topObject.localPosition = new Vector3(0, holeSize);
        bottomObject.localPosition = new Vector3(0, -holeSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }
}
