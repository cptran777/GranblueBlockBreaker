using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/**
 * This class is attached to the paddle and is used to handle the player control of the paddle behavior
 */
public class PaddleHandler : MonoBehaviour {
    [Tooltip("Increased sensitivity to move the paddle based on input")]
    [SerializeField] float movementMultiplier = 1f;

    /**
     * Reference to the camera object in the scene, allowing us to match up against the view port in order to 
     * determine the limits to which the paddle can move
     */    
    Camera mainCamera;

    void Start() {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update() {
        MovePaddle();
    }

    /**
     * Based on user input, moves the paddle left or right in the screen. Note we limit the paddle from going off screen
     * to either the left or right    
     */
    private void MovePaddle() {
        // Normalizes the possibility of sensitive mice going over
        float deltaMovement = Mathf.Clamp(CrossPlatformInputManager.GetAxis("Horizontal"), -1, 1);
        // Offset for framerate
        deltaMovement = deltaMovement * Time.deltaTime * movementMultiplier;
        float currentPosition = transform.position.x;

        // Helps us keep the paddle from being able to go too far off the screen to the right
        Vector3 topRightCameraPosition = mainCamera.ScreenToWorldPoint(new Vector3(mainCamera.pixelWidth, mainCamera.pixelHeight));
        float maxXValue = topRightCameraPosition.x;

        transform.position = new Vector2(
            Mathf.Clamp(currentPosition + deltaMovement, 0, maxXValue), 
            transform.position.y
        );
    }
}
