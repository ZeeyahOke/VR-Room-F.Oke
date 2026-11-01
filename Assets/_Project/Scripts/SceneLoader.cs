using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string hubSceneName = "Hub";
    [SerializeField] private string otherRoomSceneName;

    private bool isLoading;

    public void LoadScene(string sceneName)
    {
        if (isLoading)
        {
            return;
        }

        isLoading = true;
        StartCoroutine(FadeAndLoad(sceneName));
    }

    public void LoadHub()
    {
        LoadScene(hubSceneName);
    }

    public void LoadOtherRoom()
    {
        LoadScene(otherRoomSceneName);
    }

    private IEnumerator FadeAndLoad(string sceneName)
    {
        ScreenFade fade = FindFirstObjectByType<ScreenFade>();
        if (fade != null)
        {
            yield return fade.FadeOut();
        }

        SceneManager.LoadSceneAsync(sceneName);
    }
}
