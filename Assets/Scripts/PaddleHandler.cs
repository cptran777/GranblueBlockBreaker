using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PaddleHandler : MonoBehaviour {
    [Tooltip("Increased sensitivity to move the paddle based on input")]
    [SerializeField] float movementMultiplier = 1f;

    void Start() {
        print("We're starting?");
    }

    void Update() {
        MovePaddle();
    }

    private void MovePaddle() {
        // Normalizes the possibility of sensitive mice going over
        float deltaMovement = Mathf.Max(Mathf.Min(1, CrossPlatformInputManager.GetAxis("Horizontal")), -1);
        // Offset for framerate
        deltaMovement = deltaMovement * Time.deltaTime * movementMultiplier;
        float currentPosition = transform.position.x;
        // 0f for y since the paddle only moves in 2 directions
        transform.position = new Vector2(currentPosition + deltaMovement, transform.position.y);
    }
}
