using UnityEngine;

/// <summary>
/// This script moves the pipe GameObject to the left continuously,
/// simulating the effect of the bird flying forward while the environment scrolls.
/// Attach this to each pipe prefab.
/// </summary>
public class PipeMoveScript : MonoBehaviour
{
    // Speed at which the pipe moves to the left (units per second)
    public float moveSpeed = 5;
    public float deadZone = -22;

    /// <summary>
    /// Called once when the object is initialized.
    /// Not used in this script but can be used for future setup.
    /// </summary>
    void Start()
    {
        // No initialization needed for now
    }

    /// <summary>
    /// Called once per frame.
    /// Moves the pipe to the left based on the move speed and frame time.
    /// </summary>
    void Update()
    {
        // Move the pipe leftward continuously at a fixed speed
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Debug.Log("Pipe Deleted!");
            Destroy(gameObject);
        }
    }
}
