using UnityEngine;

public class ball_move : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 15f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(1f, 1f).normalized * speed;
    }

    void Update()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
        FixVerticalBounce();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            float y = HitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            float x = rb.linearVelocity.x > 0 ? 1 : -1;
            Vector2 dir = new Vector2(-x, y).normalized;

            rb.linearVelocity = dir * speed;
        }

        if (collision.collider.CompareTag("Wall"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -rb.linearVelocity.y);
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 paddlePos, float paddleHeight)
    {
        return (ballPos.y - paddlePos.y) / paddleHeight;
    }

    void FixVerticalBounce()
    {
        // Prevent vertical stuck
        if (Mathf.Abs(rb.linearVelocity.x) < 0.3f)
        {
            float x = rb.linearVelocity.x > 0 ? 1 : -1;
            rb.linearVelocity = new Vector2(x, rb.linearVelocity.y).normalized * speed;
        }
    }
}
