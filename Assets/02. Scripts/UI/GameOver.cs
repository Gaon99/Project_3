using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameoverCanvas;
    public TextMeshProUGUI CurrentScore;

    void Start() // 종료시 현재 점수 및 Canvas 가시화
    {
        GameoverCanvas.SetActive(true);
        CurrentScore.text = GameManager.Instance.curScore.ToString();
    }
}
