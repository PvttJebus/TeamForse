using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public Button loadButton;

    private void Start()
    {
        if (loadButton != null)
        {
            loadButton.onClick.AddListener(LoadScene);
        }
        else
        {
            Debug.LogWarning("Button reference not set in the Inspector.");
        }
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Reset time scale in case the game was paused
            Time.timeScale = 1f;

            // Load the scene
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name not set in the Inspector.");
        }
    }
}
