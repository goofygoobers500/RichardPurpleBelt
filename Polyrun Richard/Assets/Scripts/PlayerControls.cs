using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        posX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public float jumpPower = 6f;
    public bool isGrounded = false;
    float posX = 0.0f;
    Rigidbody2D rb;

    private void FixedUpdate()
    {
        


        if (Input.GetKey(KeyCode.Space) && isGrounded)
                {


            rb.AddForce(Vector3.up * (jumpPower * rb.mass * rb.gravityScale * 20.0f));


        }
    }
}
