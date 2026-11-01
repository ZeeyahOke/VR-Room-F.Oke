using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private PlayerComfort comfort;
    [SerializeField] private Toggle snapTurnToggle;
    [SerializeField] private Toggle vignetteToggle;

    private void OnEnable()
    {
        snapTurnToggle.SetIsOnWithoutNotify(comfort.SnapTurning);
        vignetteToggle.SetIsOnWithoutNotify(comfort.VignetteOn);
    }
}
