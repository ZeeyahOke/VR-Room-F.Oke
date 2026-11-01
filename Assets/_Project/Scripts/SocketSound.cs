using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

[RequireComponent(typeof(XRSocketInteractor))]
public class SocketSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip snapClip;

    private XRSocketInteractor socket;

    private void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnSnapped);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnSnapped);
    }

    private void OnSnapped(SelectEnterEventArgs args)
    {
        if (Time.timeSinceLevelLoad > 1f)
        {
            source.PlayOneShot(snapClip);
        }
    }
}
