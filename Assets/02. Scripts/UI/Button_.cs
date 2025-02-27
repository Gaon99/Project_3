using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // UI ��Ҹ� ����� �� UnityEngine.UI �ʿ�

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
            btn.onClick.AddListener(() => LoadScene(SceneValue)); //LoadScene()�� ���� �� �̵�
        }
        return btn;
    }
}
