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
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadHub()
    {
        LoadScene(hubSceneName);
    }

    public void LoadOtherRoom()
    {
        LoadScene(otherRoomSceneName);
    }
}
