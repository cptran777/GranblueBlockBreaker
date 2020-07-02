using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class BallHandler : MonoBehaviour {
    [Tooltip("Reference to the paddle object that we are locking this ball to")]
    [SerializeField] PaddleHandler paddle;

    [Tooltip("When released, how fast the ball bounces up")]
    [SerializeField] float releaseUpwardVelocity = 15f;

    [Tooltip("When released, how far off to the side the ball goes")]
    [SerializeField] float releaseSideVelocity = 1.1f;

    [Tooltip("Clips to randomly play when the ball bounces off something")]
    [SerializeField] AudioClip[] bounceAudioClips;

    /**
     * If unreleased, the game hasn't been started yet and is held to the paddle
     */
    bool isReleased = false;

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (!isReleased) {
            StickBallToPaddle();
            LaunchOnSubmit();
        }
    }

    /**
     * As long as we're not released from the paddle, the ball's x position should stay consisent with the
     * paddle's x position
     */    
    private void StickBallToPaddle() {
        transform.position = new Vector2(paddle.transform.position.x, transform.position.y);
    }

    private void LaunchOnSubmit() {
        if (CrossPlatformInputManager.GetButtonDown("Submit")) {
            isReleased = true;
            Rigidbody2D ballRigidBody = GetComponent<Rigidbody2D>();
            ballRigidBody.velocity = new Vector2(releaseSideVelocity, releaseUpwardVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (isReleased) {
            AudioClip selectedBounceSound = bounceAudioClips[UnityEngine.Random.Range(0, bounceAudioClips.Length)];
            audioSource.PlayOneShot(selectedBounceSound);
        }
    }
}
