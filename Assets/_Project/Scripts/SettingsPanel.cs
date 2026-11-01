using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private PlayerComfort comfort;
    [SerializeField] private Toggle snapTurnToggle;
    [SerializeField] private Toggle vignetteToggle;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void OnEnable()
    {
        snapTurnToggle.SetIsOnWithoutNotify(comfort.SnapTurning);
        vignetteToggle.SetIsOnWithoutNotify(comfort.VignetteOn);
        musicSlider.SetValueWithoutNotify(AudioPrefs.Get(AudioPrefs.MusicKey));
        sfxSlider.SetValueWithoutNotify(AudioPrefs.Get(AudioPrefs.SfxKey));
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
