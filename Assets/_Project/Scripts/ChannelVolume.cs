using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ChannelVolume : MonoBehaviour
{
    [SerializeField] private bool isMusic;

    private AudioSource source;
    private float baseVolume;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        baseVolume = source.volume;
    }

    private void OnEnable()
    {
        AudioPrefs.Changed += Apply;
        Apply();
    }

    private void OnDisable()
    {
        AudioPrefs.Changed -= Apply;
    }

    private void Apply()
    {
        string key = isMusic ? AudioPrefs.MusicKey : AudioPrefs.SfxKey;
        source.volume = baseVolume * AudioPrefs.Get(key);
    }
}
