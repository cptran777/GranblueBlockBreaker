using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    [Tooltip("Serialized for debugging purposes")]
    [SerializeField] int breakableBlocks = 0;

    void Start() {
        
    }

    void Update() {
        
    }

    /**
     * Increase the amount of blocks tracked, each block calls this so that it
     * can count itself
     */    
    public void AddToBreakableBlocks() {
        breakableBlocks += 1;
    }

    public void OnBlockDestroyed() {
        breakableBlocks -= 1;
        if (breakableBlocks <= 0) {
            LevelVictory();
        }
    }

    private void LevelVictory() {
        FindObjectOfType<SceneHandler>().LoadNextScene();
    }
}
