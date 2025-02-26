using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image Image;
    private float MinFill = 0.18f;  // 최솟값
    private float Init = 0.938f; // 최댓값

    void Start()
    {
        Image.fillAmount = Init;
    }

    void Update()
    {
        if (Image.fillAmount <= 0.94)
        {
            Image.fillAmount -= Time.deltaTime * 0.05f; // 천천히 증가
        }
    }

    public void SetFillAmount(float value)
    {
        value = Mathf.Clamp01(value);
        Image.fillAmount = MinFill + (value * (Init - MinFill));

    }
}
