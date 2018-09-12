using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    //state
    Vector2 paddleToBallVector;
    public bool hasStarted = false;

    // cached component references
    AudioSource myAudioSource;
    Rigidbody2D rigidBody2D;

    // Use this for initialization
    void Start ()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rigidBody2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                rigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
            }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            rigidBody2D.velocity += velocityTweak;
           // rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, rigidBody2D.velocity.y + randomFactor);
        }
        
    }
}
