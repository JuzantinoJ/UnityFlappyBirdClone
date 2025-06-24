using System.Threading;
using UnityEngine;

/// <summary>
/// This script is responsible for spawning pipes at regular intervals,
/// simulating the obstacles in a Flappy Bird-style game.
/// Attach this script to an empty GameObject that serves as the pipe spawner.
/// </summary>
public class PipeSpawnScript : MonoBehaviour
{
    // The pipe prefab to be spawned
    public GameObject pipe;

    // How often pipes should be spawned (in seconds)
    public float spawnRate = 2;

    // Timer to keep track of time between spawns
    private float timer = 0;

    public float heightOffset = 10;

    /// <summary>
    /// Called once when the game starts.
    /// You can use this for initialization if needed.
    /// </summary>
    void Start()
    {
        // spawn a new pipe
        spawnPipe();
    }

    /// <summary>
    /// Called once per frame.
    /// This checks if enough time has passed to spawn a new pipe.
    /// </summary>
    void Update()
    {
        // Only spawn pipes if game has started
        if (!LogicScript.gameIsActive) return;
        
        // Increment timer by the time passed since last frame
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // Time to spawn a new pipe
            spawnPipe();

            // Reset timer to 0 to start counting again
            timer = 0;
        }
    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0 ), transform.rotation);
    }
}
