using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PanelFade : MonoBehaviour
{
    [SerializeField] private float duration = 0.25f;
    [SerializeField] private float startScale = 0.94f;

    private CanvasGroup canvasGroup;
    private Vector3 fullScale;
    private float timer;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        fullScale = transform.localScale;
    }

    private void OnEnable()
    {
        timer = 0f;
        Apply(0f);
    }

    private void Update()
    {
        if (timer >= duration)
        {
            return;
        }

        timer += Time.unscaledDeltaTime;
        Apply(Mathf.Clamp01(timer / duration));
    }

    private void Apply(float progress)
    {
        float eased = 1f - (1f - progress) * (1f - progress);
        canvasGroup.alpha = eased;
        transform.localScale = fullScale * Mathf.Lerp(startScale, 1f, eased);
    }
}
