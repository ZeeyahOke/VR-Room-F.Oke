using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class GlowPulse : MonoBehaviour
{
    [SerializeField] private float minAlpha = 0.55f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float speed = 1.5f;

    private Graphic graphic;

    private void Awake()
    {
        graphic = GetComponent<Graphic>();
    }

    private void Update()
    {
        float wave = (Mathf.Sin(Time.unscaledTime * speed) + 1f) * 0.5f;
        Color color = graphic.color;
        color.a = Mathf.Lerp(minAlpha, maxAlpha, wave);
        graphic.color = color;
    }
}
