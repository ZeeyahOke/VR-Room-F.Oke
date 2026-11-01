using System;
using UnityEngine;

public static class AudioPrefs
{
    public const string MusicKey = "MusicVolume";
    public const string SfxKey = "SfxVolume";

    public static event Action Changed;

    public static float Get(string key)
    {
        float fallback = key == MusicKey ? 0.5f : 1f;
        return PlayerPrefs.GetFloat(key, fallback);
    }

    public static void Set(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
        PlayerPrefs.Save();
        Changed?.Invoke();
    }
}
