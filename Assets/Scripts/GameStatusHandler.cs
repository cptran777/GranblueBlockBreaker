using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusHandler : MonoBehaviour {
    [Tooltip("Modifies the speed of the game")]
    [Range(0.1f, 15)]
    [SerializeField] float gameSpeed = 1f;

    [Tooltip("Serialized only for debugging purposes")]
    [SerializeField] int currentScore = 0;

    [Tooltip("Number of points to give when a block is destroyed")]
    [SerializeField] int pointsPerBlockDestroyed = 24;

    [SerializeField] TextMeshProUGUI scoreTextMesh;

    private void Awake() {
        int gameStatusHandlerInstanceCount = FindObjectsOfType<GameStatusHandler>().Length;
        if (gameStatusHandlerInstanceCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);  
        }
    }

    private void Start() {
        scoreTextMesh.text = currentScore.ToString();
    }

    private void Update() {
        Time.timeScale = gameSpeed;
    }

    public void onAddToScore() {
        currentScore += pointsPerBlockDestroyed;
        scoreTextMesh.text = currentScore.ToString();
    }
}
