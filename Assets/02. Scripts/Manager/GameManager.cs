using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;


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
        GameStart();
    }

    public void GameStart()
    {
        health = initHealth;
        speed = initSpeed;
        curScore = 0;
        isDead = false;

        InvokeRepeating("SpeedUp", 2f, 2f); //주기적 속도 증가
        InvokeRepeating("UpScore", 1f, 1f);
    }

    public void GameOver() //패배 시 최고 점수 기록
    {
        SceneManager.LoadScene(gameOverScene);
    }

    public void CollisionObstacle() //장애물 충돌 시
    {
        health--;
        speed = initSpeed;
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
        if (speed-sp > initSpeed)
            speed -= sp;
        else speed = initSpeed;
    }

    void SpeedUp() // 속도 증가
    {
        if (isDead == false)
        {
            speed += 0.1f; //Change Speed Temporary
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
