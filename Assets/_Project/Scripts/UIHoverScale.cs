using UnityEngine;
using UnityEngine.EventSystems;

public class UIHoverScale : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float hoverScale = 1.06f;
    [SerializeField] private float pressScale = 0.96f;
    [SerializeField] private float speed = 12f;

    private Vector3 startScale;
    private float targetScale = 1f;
    private bool isHovered;

    private void Awake()
    {
        startScale = transform.localScale;
    }

    private void OnDisable()
    {
        isHovered = false;
        targetScale = 1f;
        transform.localScale = startScale;
    }

    private void Update()
    {
        Vector3 target = startScale * targetScale;
        transform.localScale = Vector3.Lerp(transform.localScale, target, speed * Time.unscaledDeltaTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
        targetScale = hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        targetScale = 1f;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        targetScale = pressScale;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        targetScale = isHovered ? hoverScale : 1f;
    }
}
