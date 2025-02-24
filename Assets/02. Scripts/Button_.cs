using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_ : MonoBehaviour
{
    public string SceneValue;

    public void LoadScene()
    {
        SceneManager.LoadScene(SceneValue);
    }
}
