using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour
{
    public Transform player; // 플레이어 위치
    public float groundWidth = 10f; //넓이
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        //현재 위치보다 더 멀리 가면
        if (player.position.x > transform.position.x + (2* groundWidth / 3))
        {
            transform.position += new Vector3(groundWidth * 2, 0, 0);
        }
    }
    /*
    public int numBgCount = 5;
    public int obstacleCount = 0; // 장애물 개수
    
    public Vector3 obstacleLastPosition = Vector3.zero; // 기본 시작 값 = Vector 0
    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>(); //Obstacle 이라는 게임 오브젝트 찾기
        obstacleLastPosition = obstacles[0].transform.position; // 첫 장애물 기준
        obstacleCount = obstacles.Length; // 정렬 수만큼 증가

        for (int i = 0; i < obstacleCount; i++)
        {
            obstacleLastPosition = obstacles[i].SetRandomPlace(obstacleLastPosition, obstacleCount); // 정렬 위치
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
