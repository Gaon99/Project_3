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
            SceneManager.sceneLoaded += OnSceneLoaded; // 씬이 로드 될때마다 OnSceneLoaded() 동작
            if (HPManager.Instance != null)
            {
                HPManager.Instance.FindCanvas();
                HPManager.Instance.CreateHPUI(); // HP UI 재생성
            }
        }
        else
        {
            Destroy(gameObject); // 중복된 UIManager 삭제
        }
        if (CurrentScore != null) CurrentScore.text = GameManager.Instance.curScore.ToString(); //CurrentScore가 null이 아닐때만 업데이트
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MapScene") // MapScene에서만 찾기
        {
            GameManager.Instance.GameStart();
            CurrentScore = GameObject.Find("CurrentScore")?.GetComponent<TextMeshProUGUI>();
            GameManager.Instance.GameStart();
            if (HPManager.Instance != null)
            {
                HPManager.Instance.FindCanvas();
                HPManager.Instance.CreateHPUI(); // HP UI 재생성
            }

        }
    }
    private void Start()
    {
        GetValue();
    }
    private void Update()
    {
        if (CurrentScore != null) CurrentScore.text = GameManager.Instance.curScore.ToString(); //CurrentScore가 null이 아닐때만 업데이트
    }

    public void UpdateValue()
    {
        currentScore = GameManager.Instance.curScore;

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

    public void GetValue() // 1,2,3등 기록 최신화
    {
        firstScore = PlayerPrefs.GetFloat("FirstScore");
        secondScore = PlayerPrefs.GetFloat("SecondScore");
        thirdScore = PlayerPrefs.GetFloat("ThirdScore");
    }
}