using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;

    private Rigidbody2D rb;
    private GameObject player;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        player = GameObject.FindGameObjectWithTag("Player");

        GameObject manager =
            GameObject.FindGameObjectWithTag("GameManager");

        if (manager != null)
        {
            scoreManager = manager.GetComponent<ScoreManager>();
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (scoreManager != null && scoreManager.IsGameOver())
        {
            return;
        }

        Vector2 direction =
            ((Vector2)player.transform.position - rb.position).normalized;

        rb.MovePosition(
            rb.position + direction * speed * Time.fixedDeltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (scoreManager != null)
            {
                scoreManager.LoseGame();
            }
        }
    }
}