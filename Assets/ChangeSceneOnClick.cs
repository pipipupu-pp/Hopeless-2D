using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnClick : MonoBehaviour
{
    public string sceneName = "Stage"; // Name of the scene to load

    public void OnButtonClick()
    {
        SceneManager.LoadScene(sceneName);
    }
}