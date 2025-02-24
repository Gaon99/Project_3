using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    UIManager uiManager;

    public TextMeshProUGUI FirstScore;
    public TextMeshProUGUI SecondScore;
    public TextMeshProUGUI ThirdScore;
    public TextMeshProUGUI time;

    public GameObject _Lobby;

    float firstScore;
    float secondScore;
    float thirdScore;

    private string FirstScoreKey = "FirstScore";
    private string SecondScoreKey = "SecondScore";
    private string ThirdScoreKey = "ThirdScore";

    // Start is called before the first frame update
    void Start()
    {

        uiManager = UIManager.Instance;
        _Lobby.GetComponentInChildren<TextMeshProUGUI>();

        firstScore = PlayerPrefs.GetFloat(FirstScoreKey, 0f);
        secondScore = PlayerPrefs.GetFloat(SecondScoreKey, 0f);
        thirdScore = PlayerPrefs.GetFloat(ThirdScoreKey, 0f);

        UpdateText();
    }
    private void Update()
    {
        float time_ = Time.time;
        int minutes = Mathf.FloorToInt(time_ / 60); // 전체 시간에서 분을 계산
        int seconds = Mathf.FloorToInt(time_ % 60); // 남은 초를 계산
        time.text = string.Format("{0}:{1:00}", minutes, seconds);
        UpdateText();

    }

    private void UpdateText()
    {
        uiManager.UpdateValue();
        uiManager.CalculateTime(firstScore, FirstScore);
        uiManager.CalculateTime(secondScore, SecondScore);
        uiManager.CalculateTime(thirdScore, ThirdScore);
    }

}


