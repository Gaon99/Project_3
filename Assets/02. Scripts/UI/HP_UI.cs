using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    public Image Image;
    private float lerpSpeed = 5f;

    void Start()
    {
        Image.fillAmount = 0;  // 초기 체력 100%
    }

    public void SetHP(float value)
    {
        StartCoroutine(AnimateHP(value));
    }

    private IEnumerator AnimateHP(float targetFill)
    {
        float startFill = Image.fillAmount;
        float time = 0f;
        float duration = 0.5f;

        while (time < duration)
        {
            time += Time.deltaTime;
            Image.fillAmount = Mathf.Lerp(startFill, targetFill, time / duration);
            yield return null;
        }

        Image.fillAmount = targetFill;
    }

    public bool IsActive()
    {
        return Image.fillAmount > 0;
    }
}
