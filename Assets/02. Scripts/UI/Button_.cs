using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI 요소를 사용할 때 UnityEngine.UI 필요

public class Button_ : MonoBehaviour
{
    private void Awake()
    {
        InitButton("RetryBtn", "MapScene");
        InitButton("LobbyBtn", "LobbyScene");
        InitButton("LobbyPlayBtn", "MapScene");
    }

    public void LoadScene(string SceneValue)
    {
        SceneManager.LoadScene(SceneValue);
    }

    private Button InitButton(string btnName, string SceneValue)
    {
        Button btn = GameObject.Find(btnName)?.GetComponent<Button>();

        if (btn != null)
        {
            btn.onClick.AddListener(() => LoadScene(SceneValue));
        }
        return btn;
    }
}
