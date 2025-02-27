using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameoverCanvas;
    public TextMeshProUGUI CurrentScore;

    void Start() // ����� ���� ���� �� Canvas ����ȭ
    {
        GameoverCanvas.SetActive(true);
        CurrentScore.text = GameManager.Instance.curScore.ToString();
    }
}
