using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    public TextMeshProUGUI FirstScore;
    public TextMeshProUGUI SecondScore;
    public TextMeshProUGUI ThirdScore;
    public GameObject _Lobby;

    private string BestScoreKey = "BestScore";
    private string SecondScoreKey = "SecondScore";
    private string ThirdScoreKey = "ThirdScore";

    // Start is called before the first frame update
    void Start()
    {
        _Lobby.GetComponentInChildren<TextMeshProUGUI>();

        int firstScore= PlayerPrefs.GetInt(BestScoreKey);
        int secondScore = PlayerPrefs.GetInt(SecondScoreKey);
        int thirdScore = PlayerPrefs.GetInt(ThirdScoreKey); 
        
        FirstScore.text = firstScore.ToString();
        SecondScore.text = secondScore.ToString();
        ThirdScore.text = thirdScore.ToString();

    }
}
