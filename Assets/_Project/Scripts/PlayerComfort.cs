using UnityEngine;

public class PlayerComfort : MonoBehaviour
{
    private const string SnapTurnKey = "SnapTurning";
    private const string VignetteKey = "ComfortVignette";

    [SerializeField] private GameObject snapTurn;
    [SerializeField] private GameObject smoothTurn;
    [SerializeField] private GameObject vignette;

    public bool SnapTurning => PlayerPrefs.GetInt(SnapTurnKey, 1) == 1;
    public bool VignetteOn => PlayerPrefs.GetInt(VignetteKey, 0) == 1;

    private void Start()
    {
        ApplyTurning(SnapTurning);
        vignette.SetActive(VignetteOn);
    }

    public void SetSnapTurning(bool isOn)
    {
        Save(SnapTurnKey, isOn);
        ApplyTurning(isOn);
    }

    public void SetVignette(bool isOn)
    {
        Save(VignetteKey, isOn);
        vignette.SetActive(isOn);
    }

    private void ApplyTurning(bool useSnap)
    {
        snapTurn.SetActive(useSnap);
        smoothTurn.SetActive(!useSnap);
    }

    private void Save(string key, bool isOn)
    {
        PlayerPrefs.SetInt(key, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}
