using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    /**
     * Loads the next scene in the build settings. Loops back around if we are
     * on the ending scene and need to go to the next    
     */
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((currentSceneIndex + 1) % totalSceneCount);
    }

    /**
     * Loads the game over screen. Allows us to be able to hit this screen from as as we have reference to the 
     * SceneHandler
     */    
    public void LoadGameOver() {
        // The game over screen is assumed to be the last scene in our build settings
        int totalSceneCount = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(totalSceneCount - 1);
    }

    /**
     * Quits the current application
     */
    public void QuitApplication() {
        Application.Quit();
    }
}
