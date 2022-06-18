using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    float horizontal;
    float vertical;
    bool stop;
    
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        CheckInputs();
    }


    private void FixedUpdate()
    {
        Movement();
        Stop();
    }

    void CheckInputs()
    {
        horizontal = Input.GetAxisRaw("Horizontal");                     // Horizontal Movement Input (values between -1 - 0 - 1)
        vertical = Input.GetAxisRaw("Vertical");
        stop = Input.GetKey(KeyCode.Space);
    }

    void Movement()
    {
        //speed = (float)(speed + 0.1 * Time.deltaTime);
        rb.velocity = new Vector2(horizontal, vertical) * (speed + 2) * Time.deltaTime;
    }

    void Stop()
    {
        if (stop)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "FakeDoor")
        {
            Debug.Log("This is Fake Door");
        }
    }
}
