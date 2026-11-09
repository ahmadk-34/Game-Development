using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int targetScore = 1000;

    private int currentScore = 0;
    private bool gameOver = false;

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void AddScore(int points)
    {
        if (gameOver)
        {
            return;
        }

        currentScore += points;

        Debug.Log("Current Score: " + currentScore);

        if (currentScore >= targetScore)
        {
            gameOver = true;

            Debug.Log("you won");
        }
    }

    public void LoseGame()
    {
        if (gameOver)
        {
            return;
        }

        gameOver = true;

        Debug.Log("you lose");
    }
}