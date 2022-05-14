using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpd; //Movement Speed
    public float JumpFrc = 1; //Jump Force
    public float JumpAng;
    public float  healthVal = 100; //Inital Health Value
    public float timer = 60.0f; //Timer for damage
    public Rigidbody2D _rigidbody; //Rigid Body
    public BoxCollider2D collid;
    public bool burn = false; // Sets burn Damage to false
    public bool runChek = false;//for sprinting
    public bool crchChk = false;//for crouching
    public bool jumpChk = false;//for jumping
    Grab gr;// sets status is grabbed for movement speed
    //for Respawning when falling into pits
    private Vector3 rspwnPnt; // respawn point
    public GameObject pitDetc;// pit detection
    public Animator animator;//for player animations

    private bool playerCanAct = true;

    //stamina Controller
    public float playerStamina = 100.0f;
    public float maxStamina = 100.0f;
    public int jumpCost = 20;
    public float staminaDrain = 15.0f;
    public float staminaRegen = 25.0f;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();        
        rspwnPnt = transform.position;
        gr = GetComponent<Grab>();
        //MoveSpd = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (playerCanAct)
        {
            var movement = Input.GetAxis("Horizontal");
            if (Mathf.Abs(movement) > 0 && runChek == false && gr.grabChk == false)
            {
                MoveSpd = 15;
            }
            else if (movement == 0)
            {
                MoveSpd = 0;
                if (playerStamina < 100.0f)
                {
                    playerStamina += staminaRegen * Time.deltaTime;
                }
            }
            
            animator.SetFloat("SPD", Mathf.Abs(MoveSpd));
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpd;

            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
                JumpAng = movement > 0 ? JumpAng = 20 : JumpAng = -20;
            }

            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001)
            {
                jumpChk = true;
                _rigidbody.AddForce(new Vector2(0, JumpFrc), ForceMode2D.Impulse);
                
            }
            else if (Input.GetButtonDown("Jump") && Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(_rigidbody.velocity.y) < 0.001)
            {
                jumpChk = true;
                _rigidbody.AddForce(new Vector2(JumpAng, JumpFrc), ForceMode2D.Impulse);

            }
            else 
            {
                jumpChk = false;
                
            }

            if (Input.GetKey("space"))
            {
                collid.size = new Vector2(collid.size.x, 3.5f);
                collid.offset = new Vector2(0, -2.9f);
            }
            /*else { 
                collid.size = new Vector2(collid.size.x, 7f);
                collid.offset = new Vector2(0, -1.147533f);
            }*/

            animator.SetBool("JMP", jumpChk);
            pitDetc.transform.position = new Vector2(transform.position.x, pitDetc.transform.position.y);

            if (Input.GetKey(KeyCode.LeftShift) && gr.grabChk == false)
            {
                runChek = true;
            }
            else
            {
                runChek = false;
            }

            if (runChek == true)
            {
                while (MoveSpd < 40)
                {
                    MoveSpd += 1;
                }
            }
            else
            {
                while (MoveSpd > 15)
                {
                    MoveSpd -= 1;
                }
            }


            if (runChek == false && gr.grabChk == true)
            {
                animator.SetBool("GRB", gr.grabChk);
            }
        }

        if (Input.GetKey(KeyCode.LeftControl)) {
            crchChk = true;
            collid.size = new Vector2(collid.size.x,3.5f);
            collid.offset = new Vector2(0, -2.9f);
        }
        else 
        {
            crchChk = false;
            collid.size = new Vector2(collid.size.x, 7f);
            collid.offset = new Vector2(0, -1.147533f);
        }


            animator.SetBool("CRH", crchChk);

        if (playerStamina <= 50.0f)
        {
            MoveSpd = 15; // you are tired
            runChek = false;
        }
        if (playerStamina <= 25.0f)
        {
            MoveSpd = 0;
            runChek = false;
        }

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = 60;
        }
        if (MoveSpd == 40)
        {
            playerStamina -= staminaDrain * Time.deltaTime;
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pit")
        {
            transform.position = rspwnPnt;
        }
        if (collision.tag == "hurtbox")
        {
            healthVal -= 55;

        }

        if (collision.tag == "burndmg")
        {
            burn = true;
        }
        if (timer > 0 && burn == true)
        {
            healthVal -= Time.deltaTime;

        }
        else
        {
            burn = false;
            timer = 0;
        }
}

    public void UpdateHealth(float mod)
    {
        healthVal += mod;
        if (healthVal <= 66)
        {
            MoveSpd = 5;
        }

        else if (healthVal <= 0f)
        {
            
            PlayerDied();
            transform.position = rspwnPnt;
            healthVal = 100;
        }
    }
    public void EnableMovement(bool flag)
    {
        playerCanAct = flag;
    }

    public bool CanAct() { return playerCanAct; }

    private void PlayerDied()
    {
        LevelManager.instance.GameOver();
        gameObject.SetActive(false);
    }

}
