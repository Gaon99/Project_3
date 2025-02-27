using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    [SerializeField] private Image EmptyHP; //  EmptyHP를 별도로 지정
    [SerializeField] private float animationSpeed = 5f;
    private Coroutine hpCoroutine;

    public void InitHP(float initialValue)
    {
        EmptyHP.fillAmount = 1f - initialValue; //  체력이 있을 때 Empty는 0
    }

    public void SetHP(float value)
    {
        if (hpCoroutine != null)
            StopCoroutine(hpCoroutine);

        hpCoroutine = StartCoroutine(AnimateHP(1f - value)); //  체력이 줄어들면 Empty는 증가
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
        return EmptyHP.fillAmount < 1; //  EmptyHP가 꽉 차면 비활성
    }

    public IEnumerator AnimateToFull()
    {
        if (gameObject.activeInHierarchy && EmptyHP.fillAmount < 1)
        {
            if (hpCoroutine != null)
                StopCoroutine(hpCoroutine);

            yield return StartCoroutine(AnimateHP(1)); //  HP 감소 → EmptyHP 채우기
        }
    }

    public float GetFillAmount()
    {
        return 1f - EmptyHP.fillAmount; //  반대로 계산하여 체력 반환
    }
}
