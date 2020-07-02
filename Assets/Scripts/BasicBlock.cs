using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour {
    /**
     * Cached reference to the level object
     */
    LevelHandler level;

    /**
     * Cached reference to the game status object, which holds the current score we'll need to modify on a 
     * block destoryed event
     */    
    GameStatusHandler gameStatus;

    void Start() {
        level = FindObjectOfType<LevelHandler>();
        level.AddToBreakableBlocks();
        gameStatus = FindObjectOfType<GameStatusHandler>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        level.OnBlockDestroyed();
        gameStatus.onAddToScore();
        Destroy(gameObject);
    }
}
