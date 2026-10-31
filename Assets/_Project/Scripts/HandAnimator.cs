using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimator : MonoBehaviour
{
    private static readonly int GripId = Animator.StringToHash("Grip");
    private static readonly int TriggerId = Animator.StringToHash("Trigger");

    [SerializeField] private InputActionProperty gripAction;
    [SerializeField] private InputActionProperty triggerAction;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(GripId, ReadValue(gripAction));
        animator.SetFloat(TriggerId, ReadValue(triggerAction));
    }

    private float ReadValue(InputActionProperty property)
    {
        InputAction action = property.action;
        if (action == null)
        {
            return 0f;
        }
        return action.ReadValue<float>();
    }
}
