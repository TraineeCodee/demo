using UnityEditor.Callbacks;
using UnityEngine;

public class move_1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per fr

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            move = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            move = -speed;
        }

        rb.linearVelocity = new Vector2(0f, move);
    }
}
