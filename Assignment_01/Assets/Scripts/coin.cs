using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 10;

    private ScoreManager scoreManager;
    private CoinSpawner coinSpawner;

    void Start()
    {
        GameObject manager =
            GameObject.FindGameObjectWithTag("GameManager");

        if (manager != null)
        {
            scoreManager = manager.GetComponent<ScoreManager>();
            coinSpawner = manager.GetComponent<CoinSpawner>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (scoreManager == null || coinSpawner == null)
        {
            return;
        }

        if (scoreManager.IsGameOver())
        {
            return;
        }

        scoreManager.AddScore(scoreValue);

        Debug.Log("Collected coin! Value: " + scoreValue);

        if (!scoreManager.IsGameOver())
        {
            coinSpawner.CoinCollected();
        }

        Destroy(gameObject);
    }
}