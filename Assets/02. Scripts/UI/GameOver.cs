using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameoverCanvas;
    public TextMeshProUGUI CurrentScore;
    private string CurrentScoreKey = "CurrentScore";
    UIManager uiManager;
    void Start()
    {
        uiManager = UIManager.Instance;

        GameoverCanvas.SetActive(true);
        // 인게임 스코어

        float Score = PlayerPrefs.GetFloat(CurrentScoreKey);
        //uiManager.CalculateTime(Score, CurrentScore);
    }

    public void Gameover()
    {
        GameoverCanvas.SetActive(true);
    }
}
