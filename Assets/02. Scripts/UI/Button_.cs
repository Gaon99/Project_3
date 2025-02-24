using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ : MonoBehaviour
{
    public string SceneValue;
    UIManager uiManager;

    private void Start()
    {
        uiManager = UIManager.Instance;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(SceneValue);
    }

    public void SetTimer()
    {
        PlayerPrefs.SetFloat("CurrentScore", Time.time);
        uiManager.UpdateValue();
    }
}
