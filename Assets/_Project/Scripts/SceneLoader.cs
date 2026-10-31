using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string hubSceneName = "Hub";

    private bool isLoading;

    public void LoadScene(string sceneName)
    {
        if (isLoading)
        {
            return;
        }

        isLoading = true;
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadHub()
    {
        LoadScene(hubSceneName);
    }
}
