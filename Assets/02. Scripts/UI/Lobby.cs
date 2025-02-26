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


    void Start()
    {
        UIManager.Instance.GetValue();
        UpdateText();
    }

    private void UpdateText()
    {
        UIManager.Instance.UpdateValue();
        FirstScore.text = UIManager.Instance.firstScore.ToString();
        SecondScore.text = UIManager.Instance.secondScore.ToString();
        ThirdScore.text = UIManager.Instance.thirdScore.ToString();
    }

}


