using UnityEngine;
using UnityEngine.SceneManagement;

public class Reload : MonoBehaviour
{
    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Reload the current scene
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
    }
}
