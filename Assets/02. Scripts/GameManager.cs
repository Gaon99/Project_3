using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float initSpeed = 3f; //ó���ӵ�
    public float speed;
    public int curScore = 0;
    public int maxScore = 0;
    public int health;
    bool isDead = false;

    static GameManager gameManager;
    public static GameManager Instance { get { return gameManager; } }

    private void Awake()
    {

        if(gameManager != null && gameManager != this)
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
        InvokeRepeating("SpeedUp", 1f, 1f); //���� �ð����� �ӵ� ����

    }
    private void Update()
    {
        if(isDead != true)
            curScore += (int)speed;
    }

    public void GameOver() //���� ������ �ְ� ���� ����
    {
        if (maxScore < curScore)
        {
            maxScore = curScore;
        }
        Time.timeScale = 0f;
    }

    public void Restart() //���� �����
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CollisionObstacle() //��ֹ� �浹 ��
    {
        health--;
        if (health <= 0)
        {
            isDead = true;
            GameOver();
        }
    }

    public void GetPotion() // ü�� ȸ�� ������ ȹ�� ��
    {
        health++;
    }

    public void GetSpeedUp(bool isUp) //�ӵ� ���� ȹ�� ��
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
    

    IEnumerator TempSpeed(float sp) //���� �ð� �� �ӵ� ����
    {
        speed += sp;
        yield return new WaitForSeconds(5f);
        speed -= sp;
    }

    void SpeedUp() // ���� �� �ӵ� ����
    {
        if (isDead == false)
        {
            speed += 1f; //Change Speed Temporary
        }
        else CancelInvoke("SpeedUp");
    }

    public float GetSpeedFromGM() //�ӵ��� ����
    {
        return speed;
    }

    public int GetHealthFromGM() //ü�� �� ����
    {
        return health;
    }
}
