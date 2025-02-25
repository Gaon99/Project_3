using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float initSpeed = 3f; //처음속도
    public int initHealth = 3;
    public float speed;
    public int curScore = 0;
    public int maxScore = 0;
    public int health;
    bool isDead = false;

    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
            return;
        }

        gameManager = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        health = initHealth;
        Time.timeScale = 1f;
        speed = initSpeed;
        InvokeRepeating("SpeedUp", 1f, 1f); //일정 시간마다 속도 증가
    }
    private void Update()
    {
        if(isDead != true)
            curScore += (int)speed;
    }

    public void GameOver() //게임 오버시 최고 점수 갱신
    {
        if (maxScore < curScore)
        {
            maxScore = curScore;
        }
        Time.timeScale = 0f;
    }

    public void Restart() //게임 재시작
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CollisionObstacle() //장애물 충돌 시
    {
        health--;
        if (health <= 0)
        {
            isDead = true;
            GameOver();
        }
    }

    public void GetPotion() // 체력 회복 아이템 획득 시
    {
        health++;
    }

    public void GetSpeedUp(bool isUp) //속도 증가 획득 시
    {
        if (isUp)
        {
            TempSpeed(3f);
        }
        else
        {
            TempSpeed(-3f);
        }
    }

    IEnumerator TempSpeed(float sp) //일정 시간 후 속도 복구
    {
        speed += sp;
        yield return new WaitForSeconds(5f);
        speed -= sp;
    }

    void SpeedUp() // 생존 시 속도 증가
    {
        if (isDead == false)
        {
            speed += 1f;
        }
        else CancelInvoke("SpeedUp");
    }

    public float GetSpeedFromGM() //속도값 전달
    {
        return speed;
    }

    public int GetHealthFromGM() //체력 값 전달
    {
        return health;
    }
}
