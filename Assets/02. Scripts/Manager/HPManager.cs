using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    [SerializeField] private GameObject HPprefab; // HP UI 프리팹
    [SerializeField] private Transform HPcanvas; // Canvas

    private Transform _HP;
    private List<HP_UI> hpList = new List<HP_UI>();
    private int lastHealth;

    void Start()
    {
        _HP = GameObject.Find("EmptyHP")?.transform;
        lastHealth = GameManager.Instance.GetHealthFromGM();
        CreateHPUI();
    }

    void Update()
    {
        int currentHealth = GameManager.Instance.GetHealthFromGM();
        if (currentHealth != lastHealth)
        {
            if (currentHealth < lastHealth) DecreaseHP(lastHealth - currentHealth);
            else IncreaseHP(currentHealth - lastHealth);

            lastHealth = currentHealth;
        }
    }

    void CreateHPUI()
    {
        int maxHP = GameManager.Instance.initHealth;

        for (int i = 0; i < maxHP; i++)
        {
            GameObject hpObj = Instantiate(HPprefab, HPcanvas);
            HP_UI hpUI = hpObj.GetComponent<HP_UI>();
            hpList.Add(hpUI);

            RectTransform rectTransform = hpObj.GetComponent<RectTransform>(); // UI 설정
            if (rectTransform != null)
            {
                rectTransform.localScale = Vector3.one; // 크기 유지
                rectTransform.anchoredPosition = new Vector2(i * 100, 0); // HP 간격 조정
            }
        }
    }

    public void DecreaseHP(int damage)
    {
        StartCoroutine(DecreaseHPCoroutine(damage));
    }

    private IEnumerator DecreaseHPCoroutine(int damage)
    {
        for (int i = hpList.Count - 1; i >= 0; i--)
        {
            if (hpList[i].IsActive())
            {
                hpList[i].SetHP(0);
                damage--;

                if (damage <= 0) break;

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    public void IncreaseHP(int heal)
    {
        StartCoroutine(IncreaseHPCoroutine(heal));
    }

    private IEnumerator IncreaseHPCoroutine(int heal)
    {
        for (int i = 0; i < hpList.Count; i++)
        {
            if (!hpList[i].IsActive())
            {
                hpList[i].SetHP(1);
                heal--;

                if (heal <= 0) break;

                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
