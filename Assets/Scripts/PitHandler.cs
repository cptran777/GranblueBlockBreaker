using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitHandler : MonoBehaviour {
    /**
     * Because this is the pit, we want to take action whenever the ball falls in. For now, since there 
     * is no concept of lives of health, we will just automatically go to the game over scene
     */    
    private void OnTriggerEnter2D(Collider2D _other) {
        print("triggered");
        SceneHandler sceneHandler = FindObjectOfType<SceneHandler>();
        sceneHandler.LoadGameOver();
    }
}
