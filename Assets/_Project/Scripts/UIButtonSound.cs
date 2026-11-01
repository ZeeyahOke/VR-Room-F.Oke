using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private float hoverVolume = 0.4f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverClip != null)
        {
            source.PlayOneShot(hoverClip, hoverVolume);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickClip != null)
        {
            source.PlayOneShot(clickClip);
        }
    }
}
