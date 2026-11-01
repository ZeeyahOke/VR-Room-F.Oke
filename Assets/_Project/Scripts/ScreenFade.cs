using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class ScreenFade : MonoBehaviour
{
    [SerializeField] private float duration = 0.6f;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1f;
    }

    private void Start()
    {
        StartCoroutine(Fade(1f, 0f));
    }

    public IEnumerator FadeOut()
    {
        yield return Fade(0f, 1f);
    }

    private IEnumerator Fade(float from, float to)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, timer / duration);
            yield return null;
        }

        canvasGroup.alpha = to;
    }
}
