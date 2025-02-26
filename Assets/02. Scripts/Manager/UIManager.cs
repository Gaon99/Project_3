using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HP; // HP Prefab

    Button RetryBtn;
    Button LobbyBtn;
    Button LobbyPlayBtn;
    Button_ button_;
    private Transform _HP;
    private List<HP_UI> hpList = new List<HP_UI>();
    private int lastHealth;

    float firstScore, Currentscore, secondScore, thirdScore;

    static UIManager instance;

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
        }
        else
        {
            Destroy(gameObject); // 중복된 UIManager 삭제
        }
    }

    void Start()
    {

        _HP = GameObject.Find("EmptyHP")?.transform;
        lastHealth = GameManager.Instance.GetHealthFromGM();
        CreateHPUI();

        button_ = GetComponent<Button_>();

        InitButton(RetryBtn, "RetryBtn"); 
        InitButton(LobbyBtn, "LobbyBtn");
        InitButton(LobbyPlayBtn, "LobbyPlayBtn");

    }
    private void Update()
    {
        int currentHealth = GameManager.Instance.GetHealthFromGM();
        if (currentHealth != lastHealth)
        {
            if (currentHealth < lastHealth)  // 체력 감소
                DecreaseHP(lastHealth - currentHealth);
            else if (currentHealth > lastHealth)  // 체력 증가
                IncreaseHP(currentHealth - lastHealth);

            lastHealth = currentHealth; // 체력 값 업데이트
        }
    }

    /*
      public void CalculateTime(float time, TextMeshProUGUI text) // time을 받아 분 초로 계산
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        text.text = string.Format("{0}:{1:00}", minutes, seconds);
    }

    public void UpdateValue() 
    {
        if (firstScore < Currentscore)  //최고 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", firstScore);
            PlayerPrefs.SetFloat("FirstScore", Currentscore);
        }
        else if (secondScore < Currentscore && firstScore > Currentscore) // 2등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", secondScore);
            PlayerPrefs.SetFloat("SecondScore", Currentscore);
        }
        else if (thirdScore < Currentscore && Currentscore < secondScore) // 3등 기록 갱신 시
        {
            PlayerPrefs.SetFloat("ThirdScore", Currentscore);
        }

        firstScore = PlayerPrefs.GetFloat("FirstScore");
        secondScore = PlayerPrefs.GetFloat("SecondScore");
        thirdScore = PlayerPrefs.GetFloat("ThirdScore");
    }
    */
    void CreateHPUI()
    {
        int maxHP = GameManager.Instance.initHealth;

        for (int i = 0; i < maxHP; i++)
        {
            GameObject hpObj = Instantiate(HP, _HP);
            HP_UI hpUI = hpObj.GetComponent<HP_UI>();
            hpList.Add(hpUI);
        }
    }

    public void DecreaseHP(int damage) 
    {
        StartCoroutine(DecreaseHPCoroutine(damage));
    }

    private IEnumerator DecreaseHPCoroutine(int damage)
    {
        for (int i = hpList.Count - 1; i >= 0; i--)  // 우측부터 감소
        {
            if (hpList[i].IsActive())
            {
                hpList[i].SetHP(0);
                damage--;

                if (damage <= 0)
                    break;

                yield return new WaitForSeconds(0.2f); // 부드러운 감소 효과
            }
        }
    }

    public void IncreaseHP(int heal)
    {
        StartCoroutine(IncreaseHPCoroutine(heal));
    }

    private IEnumerator IncreaseHPCoroutine(int heal)
    {
        for (int i = 0; i < hpList.Count; i++)  // 좌측부터 회복
        {
            if (!hpList[i].IsActive())
            {
                hpList[i].SetHP(1);
                heal--;

                if (heal <= 0)
                    break;

                yield return new WaitForSeconds(0.2f); // 부드러운 회복 효과
            }
        }
    }

    private void InitButton(Button button, string btnName)
    {
        button = GameObject.Find(btnName).GetComponent<Button>();
        button.onClick.AddListener(button_.LoadScene);
    }
}