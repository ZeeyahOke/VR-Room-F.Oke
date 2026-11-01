using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOutputRestarter : MonoBehaviour
{
    [SerializeField] private float delay = 1f;

    private void OnApplicationFocus(bool hasFocus)
    {
        if (!hasFocus || Application.isEditor)
        {
            return;
        }

        StopAllCoroutines();
        StartCoroutine(RestartAfterDelay());
    }

    private IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSecondsRealtime(delay);

        List<AudioSource> looping = new List<AudioSource>();
        foreach (AudioSource source in FindObjectsByType<AudioSource>(FindObjectsSortMode.None))
        {
            if (source.isPlaying && source.loop)
            {
                looping.Add(source);
            }
        }

        AudioSettings.Reset(AudioSettings.GetConfiguration());

        foreach (AudioSource source in looping)
        {
            source.Play();
        }
    }
}
