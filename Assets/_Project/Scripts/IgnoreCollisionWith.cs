using UnityEngine;

public class IgnoreCollisionWith : MonoBehaviour
{
    [SerializeField] private Collider[] otherColliders;

    private void Awake()
    {
        Collider[] ownColliders = GetComponentsInChildren<Collider>();
        foreach (Collider own in ownColliders)
        {
            foreach (Collider other in otherColliders)
            {
                Physics.IgnoreCollision(own, other);
            }
        }
    }
}
