using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score = 0f;
    public float pointsPerSecond = 10f;
    private bool isAlive = true;

    void Update()
    {
        if (!isAlive) return;

        score += pointsPerSecond * Time.deltaTime;

        if (scoreText != null)
        {
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    public void StopScoring()
    {
        isAlive = false;
    }
}
