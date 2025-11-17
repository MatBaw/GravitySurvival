using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;          // panel GameOver
    public TextMeshProUGUI finalScoreText;    // tekst z ostatecznym wynikiem

    private ScoreManager scoreManager;
    private bool isGameOver = false;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        Time.timeScale = 1f;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return; // żeby nie wywołać dwa razy
        isGameOver = true;

        if (scoreManager != null)
        {
            scoreManager.StopScoring();
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null && scoreManager != null)
        {
            int finalScore = Mathf.FloorToInt(scoreManager.score);
            finalScoreText.text = "Score: " + finalScore.ToString();
        }

        // zatrzymujemy czas gry
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        // przy restarcie włączamy czas i ładujemy scenę od nowa
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
