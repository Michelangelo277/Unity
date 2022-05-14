using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class AIPath : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPatrol;
    public bool mustTurn;

    public RigidBody2D rb;
    public Transform groundCheckPosition;
    public LayerMask groundLayer;



    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol == true)
        {
            Patrol();
        }
    }

    void FixedUpdate()
    {
         if (mustPatrol == true)
         {
             mustTurn = Physics2D.OverlapCircle(groundCheckPosition.position, 0.1f, groundLayer);
         }
    }

    void Patrol()
    {
        if (mustTurn)
        {
            Flip();
        }
         rb.velocity = new Vector2(walkSpeed*Time.fixedDelaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

}

*/