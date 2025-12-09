using UnityEngine;
using TMPro;
using UnityEngine.UI;   // For Text UI

public class BallScore : MonoBehaviour
{
    public float boundaryX = 8.5f;  // Your screen half-width
    public TMP_Text leftScoreText;
    public TMP_Text rightScoreText;

    int leftScore = 0;
    int rightScore = 0;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Ball exits RIGHT side → Left player scores
        if (transform.position.x > boundaryX)
        {
            leftScore++;
            UpdateScore();
            ResetBall();
        }

        // Ball exits LEFT side → Right player scores
        if (transform.position.x < -boundaryX)
        {
            rightScore++;
            UpdateScore();
            ResetBall();
        }
    }

    void UpdateScore()
    {
        leftScoreText.text = leftScore.ToString();
        rightScoreText.text = rightScore.ToString();
    }

    void ResetBall()
    {
        // Center the ball
        transform.position = Vector2.zero;

        // Stop ball
        rb.linearVelocity = Vector2.zero;

        // Serve in a random direction
        Vector2 dir = new Vector2(Random.Range(-1f, 1f), Random.Range(-0.5f, 0.5f));
        rb.linearVelocity = dir.normalized * 6f;
    }
}

