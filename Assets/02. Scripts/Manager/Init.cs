using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour //GameManager와 UIManager 초기화를 위한 씬
{
    private void Start() 
    {
        Invoke("TransitionScene",0);
    }
    private void TransitionScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
