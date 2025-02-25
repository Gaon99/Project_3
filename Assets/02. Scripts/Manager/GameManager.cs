using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float initSpeed = 3f; //최초 속도
    public int initHealth = 3; //최초 체력
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
        InvokeRepeating("SpeedUp", 1f, 1f); //주기적 속도 증가
        InvokeRepeating("UpScore", 0.5f, 0.5f);

    }

    public void GameOver() //패배 시 최고 점수 기록
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

    public void GetPotion() //체력 회복 충돌 시
    {
        health++;
    }

    public void GetSpeedUp() //속도 증가 충돌 시
    {
            TempSpeed(5f);
    } 
    

    public void UpScore()
    {
        if (isDead != true)
            curScore += (int)speed;
    }
    IEnumerator TempSpeed(float sp) //속도 증가 후 일정 시간이 지나면 속도 감소
    {
        speed += sp;
        yield return new WaitForSeconds(5f);
        speed -= sp;
    }

    void SpeedUp() // 속도 증가
    {
        if (isDead == false)
        {
            speed += 1f; //Change Speed Temporary
        }
        else CancelInvoke("SpeedUp");
    }

    public float GetSpeedFromGM() //속도 전달
    {
        return speed;
    }

    public int GetHealthFromGM() //체력 전달
    {
        return health;
    }
}
