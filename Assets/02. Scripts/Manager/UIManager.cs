using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HP; // HP Prefab

    private Transform _HP;
    private List<HP_UI> hpList = new List<HP_UI>();
    private int lastHealth;

    float firstScore, Currentscore, secondScore, thirdScore;

    static UIManager instance;

    public static UIManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 UIManager 삭제
        }
    }

    /*
      public void CalculateTime(float time, TextMeshProUGUI text) // time을 받아 분 초로 계산
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void UpdateValue() 
    {
        if (firstScore < Currentscore)  //최고 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", firstScore);
            PlayerPrefs.SetFloat("FirstScore", Currentscore);
        }
        else if (secondScore < Currentscore && firstScore > Currentscore) // 2등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", Currentscore);
        }
        else if (thirdScore < Currentscore && Currentscore < secondScore) // 3등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", Currentscore);
        }

        firstScore = PlayerPrefs.GetFloat("FirstScore");
        secondScore = PlayerPrefs.GetFloat("SecondScore");
        thirdScore = PlayerPrefs.GetFloat("ThirdScore");
    }
    */


}