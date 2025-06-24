using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public GameObject gameOverScreen;
    public GameObject startScreen;
    public GameObject bird;

    public static bool gameIsActive = false;



    void Start()
    {
        // When the game starts, show the start screen and hide bird & score
        startScreen.SetActive(true);
        bird.SetActive(false);
        scoreText.gameObject.SetActive(false);
        
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        // Hide start screen, show bird and score
        startScreen.SetActive(false);
        bird.SetActive(true);
        scoreText.gameObject.SetActive(true);
        gameIsActive = true; // Game officially starts here
    }
}
