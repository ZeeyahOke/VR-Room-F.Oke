using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip impactClip;
    [SerializeField] private float minSpeed = 0.4f;
    [SerializeField] private float fullVolumeSpeed = 4f;
    [SerializeField] private float cooldown = 0.12f;

    private float lastPlayTime;

    private void OnCollisionEnter(Collision collision)
    {
        float speed = collision.relativeVelocity.magnitude;
        bool tooSoon = Time.time - lastPlayTime < cooldown;
        if (speed < minSpeed || tooSoon || Time.timeSinceLevelLoad < 1f)
        {
            return;
        }

        lastPlayTime = Time.time;
        source.PlayOneShot(impactClip, Mathf.Clamp01(speed / fullVolumeSpeed));
    }
}
