using UnityEngine;
using UnityEngine.UI;

// Minimal BallController so the GameManager reference resolves.
// You can move this to its own file later if desired.
public class BallController : MonoBehaviour
{
    public float launchForce = 200f;

    public void LaunchBall()
    {
        var rb = GetComponent<Rigidbody2D>();
        if (rb == null) return;

        // If the ball is stationary, apply a simple force to start movement.
        if (rb.linearVelocity == Vector2.zero)
        {
            rb.AddForce(new Vector2(launchForce, 0));
        }
    }
}

public class GameManager : MonoBehaviour
{
    public BallController ball;
    public Text player1ScoreText;
    public Text player2ScoreText;

    private int player1Score = 0;
    private int player2Score = 0;

    void Update()
    {
        if (ball.transform.position.x > 9) // Ball passed right side
        {
            player1Score++;
            player1ScoreText.text = player1Score.ToString();
            ResetBall();
        }
        else if (ball.transform.position.x < -9) // Ball passed left side
        {
            player2Score++;
            player2ScoreText.text = player2Score.ToString();
            ResetBall();
        }
    }

    void ResetBall()
    {
        ball.transform.position = Vector3.zero;
        ball.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        ball.LaunchBall();
    }
}
