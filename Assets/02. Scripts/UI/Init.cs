using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    private void Start()
    {
        Invoke("TransitionScene", 1f);
    }
    private void TransitionScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
