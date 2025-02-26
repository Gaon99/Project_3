using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public Transform player; // �÷��̾� ��ġ
    public float groundWidth = 10f; //����
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        //���� ��ġ���� �� �ָ� ����
        if (player.position.x > transform.position.x + (2* groundWidth / 3))
        {
            transform.position += new Vector3(groundWidth * 2, 0, 0);
        }
    }
    /*
    public int numBgCount = 5;
    public int obstacleCount = 0; // ��ֹ� ����
    
    public Vector3 obstacleLastPosition = Vector3.zero; // �⺻ ���� �� = Vector 0
    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); //Obstacle �̶�� ���� ������Ʈ ã��
        obstacleLastPosition = obstacles[0].transform.position; // ù ��ֹ� ����
        obstacleCount = obstacles.Length; // ���� ����ŭ ����

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount); // ���� ��ġ
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered: " + collision.name);

        if (collision.CompareTag("Obstacle"))
        {
            float widthOfBgObject = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;

            pos.x += widthOfBgObject * numBgCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>();
        if (obstacle)
        {
            obstacleLastPosition = obstacle.SetRandomPlace(obstacleLastPosition, obstacleCount);
        }
    }
    */

}
