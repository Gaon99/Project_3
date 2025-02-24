using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Button_ button_;
    Button RetryBtn;
    Button LobbyBtn;
    public GameObject Gameover;
    public TextMeshProUGUI CurrentScore;
    private string CurrentScoreKey = "CurrentScore";
    static UIManager instance;

    public static UIManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        // 싱글톤 패턴 적용
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        button_ = GetComponent<Button_>();
        RetryBtn?.onClick.AddListener(button_.LoadScene);
        LobbyBtn?.onClick.AddListener(button_.LoadScene);
        Gameover.SetActive(true);
    }
    void Update()
    {

        // 인게임 스코어
        //int minutes = Mathf.FloorToInt(Time.time / 60); // 전체 시간에서 분을 계산
        //int seconds = Mathf.FloorToInt(Time.time % 60); // 남은 초를 계산
        float Score = PlayerPrefs.GetFloat(CurrentScoreKey);

        int minutes = Mathf.FloorToInt(Score / 60);
        int seconds = Mathf.FloorToInt(Score % 60);
        CurrentScore.text = string.Format("{0}:{1:00}", minutes, seconds); // "0:00" 형식으로 변환
    }
    public void GameOver()
    {
        Gameover.SetActive(true);
    }



}
