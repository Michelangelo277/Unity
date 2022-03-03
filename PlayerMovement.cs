using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb1;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //Setting character movement for player between x,y,z axis
        rb1.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb1.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
        if(Input.GetButtonDown("Jump"))
        {
            rb1.velocity = new Vector3(rb1.velocity.x, jumpForce, rb1.velocity.y);
        }
    }
}
