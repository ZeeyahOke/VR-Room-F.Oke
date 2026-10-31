using UnityEngine;
using UnityEngine.InputSystem;

public class NavigationMenuToggle : MonoBehaviour
{
    [SerializeField] private InputActionProperty toggleAction;
    [SerializeField] private GameObject menu;
    [SerializeField] private Transform head;
    [SerializeField] private float distance = 1.2f;

    private void Awake()
    {
        if (head == null && Camera.main != null)
        {
            head = Camera.main.transform;
        }

        menu.SetActive(false);
    }

    private void OnEnable()
    {
        toggleAction.action.Enable();
        toggleAction.action.performed += OnTogglePressed;
    }

    private void OnDisable()
    {
        toggleAction.action.performed -= OnTogglePressed;
    }

    private void OnTogglePressed(InputAction.CallbackContext context)
    {
        Toggle();
    }

    public void Toggle()
    {
        bool show = !menu.activeSelf;
        if (show)
        {
            PlaceInFrontOfHead();
        }

        menu.SetActive(show);
    }

    public void Close()
    {
        menu.SetActive(false);
    }

    private void PlaceInFrontOfHead()
    {
        Vector3 forward = head.forward;
        forward.y = 0f;
        if (forward.sqrMagnitude < 0.01f)
        {
            forward = Vector3.forward;
        }

        forward.Normalize();
        Vector3 position = head.position + forward * distance;
        menu.transform.SetPositionAndRotation(position, Quaternion.LookRotation(forward));
    }
}
