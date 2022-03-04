using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deechar : MonoBehaviour
{

    public float MoveSpd; //Movement Speed
    public float JumpFrc = 1; //Jump Force
    public int healthVal = 100; //Inital Health Value
    public float timer = 10.0f; //Timer for damage
    private Rigidbody2D _rigidbody; //Rigid Body
    public bool burn = false; // Sets burn Damage to false
    public bool isGrabbed = false; // sets status is grabbed for movement speed
    public bool runChek = false;//for sprinting

    //for Respawning when falling into pits
    private Vector3 rspwnPnt; // respawn point
    public GameObject pitDetc;// pit detection

    
    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        rspwnPnt = transform.position;
    }

    private void Update()
    {

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpd;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001)
        {
            _rigidbody.AddForce(new Vector2(0, JumpFrc), ForceMode2D.Impulse);
        }

        pitDetc.transform.position = new Vector2(transform.position.x, pitDetc.transform.position.y);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            runChek = true;
        }
        else {
            runChek = false;
        }

        if (runChek == true)
        {
            MoveSpd = 15;
        }
        else 
        {
            MoveSpd = 7;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            isGrabbed = true;
        }
        else {
            isGrabbed = false;
        }

        if (isGrabbed == true) {
            MoveSpd = 5;
        }
        else
        {
            MoveSpd = 7;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "pit") {
            transform.position = rspwnPnt;
        }
        if (collision.tag == "hurtbox")
        {
            healthVal -= 20;

        }

        if (collision.tag == "burndmg")
        {
            burn = true;
            timer = 5;
        }
        else { 
        
        }
        while (timer > 0 && burn == true)
        {
            timer -= Time.deltaTime;
            healthVal -= 3;
            if (healthVal == 33 || healthVal == 66){
                break;
            }
        }       

        if (healthVal <= 0)
        {
            transform.position = rspwnPnt;
            healthVal = 100;
        }


    }
}


