using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private PlayerComfort comfort;
    [SerializeField] private Toggle snapTurnToggle;
    [SerializeField] private Toggle vignetteToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if (comfort == null)
        {
            comfort = FindFirstObjectByType<PlayerComfort>();
        }
    }

    private void OnEnable()
    {
        snapTurnToggle.SetIsOnWithoutNotify(comfort.SnapTurning);
        vignetteToggle.SetIsOnWithoutNotify(comfort.VignetteOn);
        musicSlider.SetValueWithoutNotify(AudioPrefs.Get(AudioPrefs.MusicKey));
        sfxSlider.SetValueWithoutNotify(AudioPrefs.Get(AudioPrefs.SfxKey));
    }

    public void SetSnapTurning(bool isOn)
    {
        comfort.SetSnapTurning(isOn);
    }

    public void SetVignette(bool isOn)
    {
        comfort.SetVignette(isOn);
    }

    public void SetDistanceGrab(bool isOn)
    {
        foreach (ToggleNearFarAttach hand in FindObjectsByType<ToggleNearFarAttach>(FindObjectsSortMode.None))
        {
            hand.SetFarAttachMode(isOn);
        }
    }

    public void SetMusicVolume(float value)
    {
        AudioPrefs.Set(AudioPrefs.MusicKey, value);
    }

    public void SetSfxVolume(float value)
    {
        AudioPrefs.Set(AudioPrefs.SfxKey, value);
    }
}
