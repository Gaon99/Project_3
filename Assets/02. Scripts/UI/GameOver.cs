using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameoverCanvas;
    public TextMeshProUGUI CurrentScore;
    UIManager uiManager;
    void Start()
    {
        GameoverCanvas.SetActive(true);
        CurrentScore.text = GameManager.Instance.curScore.ToString();
    }
}
