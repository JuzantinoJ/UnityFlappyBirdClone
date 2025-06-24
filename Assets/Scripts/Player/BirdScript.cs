using System.Security.Cryptography.X509Certificates; // ⚠️ This namespace is not needed for this script — can be removed.
using UnityEngine;

/// <summary>
/// This script controls the bird's movement (flapping) in a Flappy Bird-style game.
/// It listens for spacebar input and applies an upward velocity to simulate flapping.
/// Attach this script to the Bird GameObject with a Rigidbody2D component.
/// </summary>
public class BirdScript : MonoBehaviour
{
    // Reference to the Rigidbody2D component for physics manipulation
    public Rigidbody2D myRigidbody;

    // The upward force applied when the bird flaps
    public float flapstrength;
    public LogicScript logic;

    public bool birdIsAlive = true;

    public AudioSource audioSource;
    public AudioClip flapSound;
    public AudioClip deathSound;

    /// <summary>
    /// Called once when the game starts.
    /// Use this for any initialization (not needed here yet).
    /// </summary>
    void Start()
    {

        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    /// <summary>
    /// Called once per frame.
    /// Checks for spacebar input and makes the bird "flap" upward by changing its velocity.
    /// </summary>
    void Update()
    {
        // Check if spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            // Apply an upward velocity to the Rigidbody2D to simulate a flap
            myRigidbody.linearVelocity = Vector2.up * flapstrength;

            if (flapSound != null && audioSource != null)
                audioSource.PlayOneShot(flapSound);
            // Log to console for debugging (confirms spacebar input is detected)
            Debug.Log("Spacebar Pressed");

            // NOTE:
            // If this input doesn't work:
            // Go to Edit > Project Settings > Player
            // Under "Other Settings", change "Active Input Handling" to "Both"
            // This allows Unity to use both the old and new input systems
        }

    }

    void Die()
    {
        if (birdIsAlive)
        {
            birdIsAlive = false;
            LogicScript.gameIsActive = false;
            logic.gameOver();
        }
        // play death sound
        if (audioSource != null && deathSound != null)
            audioSource.PlayOneShot(deathSound);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Die();
        }
    }

}
