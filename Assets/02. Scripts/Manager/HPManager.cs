using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{


    [SerializeField] private GameObject HPprefab; // HP UI 프리팹
    [SerializeField] private Transform HPcanvas; // Canvas

    public List<HP_UI> hpList = new List<HP_UI>();
    private int lastHealth;

    static HPManager instance;
    public static HPManager Instance
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
        lastHealth = GameManager.Instance.health;
    }

    void Update()
    {
        int currentHealth = GameManager.Instance.health;
        if (currentHealth != lastHealth)
        {
            if (currentHealth < lastHealth)
                StartCoroutine(DecreaseHPCoroutine(lastHealth - currentHealth));
            else
                StartCoroutine(IncreaseHPCoroutine(currentHealth - lastHealth));

            lastHealth = currentHealth;
        }
    }


    public void CreateHPUI()
    {
        // 기존 HP UI 오브젝트 모두 제거
        foreach (var hp in hpList)
        {
            if (hp != null) Destroy(hp.gameObject);
        }
        hpList.Clear(); // 리스트 초기화

        int maxHP = GameManager.Instance.initHealth;
        int initialHealth = GameManager.Instance.health;

        for (int i = 0; i < maxHP; i++)
        {
            GameObject hpObj = Instantiate(HPprefab, HPcanvas);
            HP_UI hpUI = hpObj.GetComponent<HP_UI>();

            hpUI.InitHP(i < initialHealth ? 1f : 0f);
            hpList.Add(hpUI);

            RectTransform rectTransform = hpObj.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition = new Vector2(i * 65, 0); // HP 좌측 정렬
            }
        }
    }

    public IEnumerator DecreaseHPCoroutine(int damage)
    {
        int removed = 0;

        for (int i = hpList.Count - 1; i >= 0; i--)
        {
            if (hpList[i].IsActive())
            {
                yield return hpList[i].AnimateToFull();
                removed++;

                if (removed >= damage) break;

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public IEnumerator IncreaseHPCoroutine(int heal)
    {
        if (hpList.Count == 0)
        {
            CreateHPUI();
            yield return new WaitForEndOfFrame(); // 프레임 대기 후 실행
        }
        for (int i = 0; i < hpList.Count; i++)
        {
            if (hpList[i] != null && !hpList[i].IsActive()) // null 체크
            {
                yield return hpList[i].AnimateHP(1);
                heal--;

                if (heal <= 0) break;

                yield return new WaitForSeconds(0.2f);
            }
        }
    }
    public void FindCanvas()
    {
        GameObject canvasObj = GameObject.FindWithTag("HPCanvas");
        if (canvasObj != null)
        {
            HPcanvas = canvasObj.transform;
        }
    }
}