using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    [SerializeField] private Image EmptyHP; //  EmptyHP�� ������ ����
    [SerializeField] private float animationSpeed = 5f;
    private Coroutine hpCoroutine;

    public void InitHP(float initialValue)
    {
        EmptyHP.fillAmount = 1f - initialValue; //  ü���� ���� �� Empty�� 0
    }

    public void SetHP(float value)
    {
        if (hpCoroutine != null)
            StopCoroutine(hpCoroutine);

        hpCoroutine = StartCoroutine(AnimateHP(1f - value)); //  ü���� �پ��� Empty�� ����
    }

    public IEnumerator AnimateHP(float targetFill)
    {
        float startFill = EmptyHP.fillAmount;
        float time = 0f;
        float duration = 0.5f;

        while (time < duration)
        {
            time += Time.deltaTime;
            EmptyHP.fillAmount = Mathf.Lerp(startFill, targetFill, time / duration);
            yield return null;
        }

        EmptyHP.fillAmount = targetFill;    
        hpCoroutine = null;
    }

    public bool IsActive()
    {
        return EmptyHP.fillAmount < 1; //  EmptyHP�� �� ���� ��Ȱ��
    }

    public IEnumerator AnimateToFull()
    {
        if (gameObject.activeInHierarchy && EmptyHP.fillAmount < 1)
        {
            if (hpCoroutine != null)
                StopCoroutine(hpCoroutine);

            yield return StartCoroutine(AnimateHP(1)); //  HP ���� �� EmptyHP ä���
        }
    }

    public float GetFillAmount()
    {
        return 1f - EmptyHP.fillAmount; //  �ݴ�� ����Ͽ� ü�� ��ȯ
    }
}
