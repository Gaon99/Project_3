using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    public Image Image;
    private float MinFill = 0.18f;  // �ּڰ�
    private float Init = 0.938f; // �ִ�

    void Start()
    {
        Image.fillAmount = Init;
    }

    void Update()
    {
        if (Image.fillAmount <= 0.94)
        {
            Image.fillAmount -= Time.deltaTime * 0.05f; // õõ�� ����
        }
    }

    public void SetFillAmount(float value)
    {
        value = Mathf.Clamp01(value);
        Image.fillAmount = MinFill + (value * (Init - MinFill));

    }
}
