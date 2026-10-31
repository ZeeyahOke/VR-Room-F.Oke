using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ObjectResetter : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable[] objects;
    [SerializeField] private XRSocketInteractor[] sockets;
    [SerializeField] private float socketPauseSeconds = 0.5f;

    private Vector3[] startPositions;
    private Quaternion[] startRotations;

    private void Awake()
    {
        startPositions = new Vector3[objects.Length];
        startRotations = new Quaternion[objects.Length];
        for (int i = 0; i < objects.Length; i++)
        {
            startPositions[i] = objects[i].transform.position;
            startRotations[i] = objects[i].transform.rotation;
        }
    }

    public void ResetObjects()
    {
        SetSocketsActive(false);
        for (int i = 0; i < objects.Length; i++)
        {
            Release(objects[i]);
            MoveBack(objects[i], startPositions[i], startRotations[i]);
        }

        StartCoroutine(ReactivateSockets());
    }

    private IEnumerator ReactivateSockets()
    {
        yield return new WaitForSeconds(socketPauseSeconds);
        SetSocketsActive(true);
    }

    private void SetSocketsActive(bool active)
    {
        foreach (XRSocketInteractor socket in sockets)
        {
            socket.socketActive = active;
        }
    }

    private void Release(XRGrabInteractable grabbable)
    {
        if (grabbable.interactionManager == null)
        {
            return;
        }

        for (int i = grabbable.interactorsSelecting.Count - 1; i >= 0; i--)
        {
            grabbable.interactionManager.SelectExit(grabbable.interactorsSelecting[i], grabbable);
        }
    }

    private void MoveBack(XRGrabInteractable grabbable, Vector3 position, Quaternion rotation)
    {
        Rigidbody body = grabbable.GetComponent<Rigidbody>();
        if (body != null)
        {
            body.linearVelocity = Vector3.zero;
            body.angularVelocity = Vector3.zero;
            body.position = position;
            body.rotation = rotation;
        }

        grabbable.transform.SetPositionAndRotation(position, rotation);
    }
}
