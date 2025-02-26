using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public float initSpeed = 3f; //최초 속도
    public int initHealth = 3; //최초 체력
    public float speed;
    public int curScore = 0;
    public int health;
    bool isDead = false;

    string gameOverScene = "GameOverScene";


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
        gameStart();
        InvokeRepeating("SpeedUp", 1f, 1f); //주기적 속도 증가
        InvokeRepeating("UpScore", 0.5f, 0.5f);

    }

    public void gameStart()
    {
        health = initHealth;
        speed = initSpeed;
        curScore = 0;
        isDead = false;
    }

    public void GameOver() //패배 시 최고 점수 기록
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void CollisionObstacle() //장애물 충돌 시
    {
        health--;
        speed /= 2;
        if (health <= 0)
        {
            isDead = true;
            GameOver();
        }
    }

    public void GetSpeedUp(float speed) //속도 증가 충돌 시
    {
            StartCoroutine(TempSpeed(speed));
    } 
    

    public void UpScore()
    {
        if (isDead != true)
            curScore += (int)speed;
    }
    IEnumerator TempSpeed(float sp) //속도 증가 후 일정 시간이 지나면 속도 감소
    {
        speed += sp;
        yield return new WaitForSeconds(3f);
        Debug.Log("속도 감소");
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

    public int GetScore()
    {
        return curScore;
    }
}
