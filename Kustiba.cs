using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kustiba : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed;
    public float jumpSpeed;
    private bool isJumping = false;

    //public const string RIGHT = "right";
    //public const string LEFT = "left";
    //string buttonPressed;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Labāk GetAxis Horizontal, nekā katram rakstīt if, jo var jau izmantot gatavu asi(a=-1,d=1)
        float move = Input.GetAxis("Horizontal");
        //Vector2 = x,y
        rb2d.velocity = new Vector2(moveSpeed * move, rb2d.velocity.y);

        
        
       Jump();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&&!isJumping)
        {

            rb2d.AddForce(new Vector2(rb2d.velocity.x, jumpSpeed));
            isJumping = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }


}



