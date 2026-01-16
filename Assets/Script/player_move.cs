using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Hello, World!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            rb.linearVelocity = new Vector2(speed, 0f);
        else if (Input.GetKey(KeyCode.LeftArrow))
            rb.linearVelocity = new Vector2(-speed, 0f);
            if (Input.GetKey(KeyCode.UpArrow))
            rb.linearVelocity = new Vector2(rb.linearVelocityX, speed);
    }
    void Awake()
    {
        Debug.Log("Awake called!");
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("Awake loop iteration: " + i);
        }
    }
    void onMousexxx()
    {
        Debug.Log("onMousexxx called!");
    }


}
