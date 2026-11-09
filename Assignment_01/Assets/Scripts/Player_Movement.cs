using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private ScoreManager scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject manager =
            GameObject.FindGameObjectWithTag("GameManager");

        scoreManager = manager.GetComponent<ScoreManager>();
    }

    void FixedUpdate()
    {
        if (scoreManager.IsGameOver())
        {
            return;
        }

        if (Keyboard.current == null)
        {
            return;
        }

        var dValue = Keyboard.current.dKey.value;
        var aValue = Keyboard.current.aKey.value;
        var wValue = Keyboard.current.wKey.value;
        var sValue = Keyboard.current.sKey.value;

        Vector2 direction =
            dValue * Vector2.right +
            aValue * Vector2.left +
            wValue * Vector2.up +
            sValue * Vector2.down;

        rb.MovePosition(
            rb.position + direction.normalized * speed * Time.fixedDeltaTime
        );
    }
}