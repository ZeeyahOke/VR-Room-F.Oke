using UnityEngine;

public class DoorSound : MonoBehaviour
{
    [SerializeField] private Rigidbody door;
    [SerializeField] private AudioSource loopSource;
    [SerializeField] private float maxVolume = 0.6f;
    [SerializeField] private float fullSpeed = 1.5f;
    [SerializeField] private float smoothing = 8f;

    private float currentLevel;

    private void Update()
    {
        float target = Mathf.Clamp01(door.angularVelocity.magnitude / fullSpeed);
        currentLevel = Mathf.Lerp(currentLevel, target, smoothing * Time.deltaTime);
        loopSource.volume = currentLevel * maxVolume * AudioPrefs.Get(AudioPrefs.SfxKey);
        loopSource.pitch = 0.8f + currentLevel * 0.4f;
    }
}
