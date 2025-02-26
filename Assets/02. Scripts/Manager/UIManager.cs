using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public TextMeshProUGUI CurrentScore;
    public float firstScore, secondScore, thirdScore, currentScore;
    public static UIManager Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject); // 중복된 UIManager 삭제
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MapScene") // MapScene에서만 찾기
        {
            CurrentScore = GameObject.Find("CurrentScore")?.GetComponent<TextMeshProUGUI>();
        }
    }
    private void Start()
    {
        GetValue();
    }
    private void Update()
    {
        if (CurrentScore != null) CurrentScore.text = GameManager.Instance.curScore.ToString();
    }

    public void UpdateValue()
    {
        if (firstScore < currentScore)  //최고 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", firstScore);
            PlayerPrefs.SetFloat("FirstScore", currentScore);
        }
        else if (secondScore < currentScore && firstScore > currentScore) // 2등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", currentScore);
        }
        else if (thirdScore < currentScore && currentScore < secondScore) // 3등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", currentScore);
        }

        GetValue();
    }

    public void GetValue()
    {
        firstScore = PlayerPrefs.GetFloat("FirstScore");
        secondScore = PlayerPrefs.GetFloat("SecondScore");
        thirdScore = PlayerPrefs.GetFloat("ThirdScore");
    }
}