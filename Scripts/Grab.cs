using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Grab : MonoBehaviour
{
    public Transform grabDetect;//Grab Detector
    public Transform NpcHold;// NPC Holder Point
    public bool grabChk;//Check to see if an NPC is grabbed\
    public bool isHeld; 
    public float ray;// Ray for the raycast
    public float throwforce;//Force in X direction
    public float upFor;//Force in Y direction
    public Animator animator;//for player animations
    CharacterMovement CharMo;//Class CharacterMovement for Jump Force and Character Movement

    // Start is called before the first frame update
    void Start()
    {
        CharMo = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void Update()
    {
            var movement = Input.GetAxis("Horizontal");//movement for throw
            RaycastHit2D grabbed = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale, ray);//raycast
        if (grabbed.collider != null && (grabbed.collider.tag == "NPC" || grabbed.collider.tag == "NPC2"))
        {
            if (Input.GetKey(KeyCode.Q) && CharMo.runChek == false)
            {
                grabChk = true;
                isHeld = true;
                grabbed.collider.gameObject.transform.parent = NpcHold;
                grabbed.collider.gameObject.transform.position = NpcHold.position;
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            else
            {
                grabChk = false;
                isHeld = false;
                grabbed.collider.gameObject.transform.parent = null;
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            if (!Mathf.Approximately(0, movement))
            {
                throwforce = movement > 0 ? throwforce = 30 : throwforce = -30;
                upFor = movement > 0 ? upFor = -1 : upFor = 1;
            }
            //Throw
            if (Input.GetKeyUp(KeyCode.Q))
            {
                grabChk = false;
                isHeld = false;
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, upFor) * throwforce;
            }
            //Shove
            if (Input.GetKeyDown(KeyCode.E))
            {
                grabChk = true;
                if (!Mathf.Approximately(0, movement))
                {
                    throwforce = movement > 0 ? throwforce = 30 : throwforce = -30;
                    upFor = movement > 0 ? upFor = -0.2f : upFor = 0.2f;

                }
                grabbed.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, upFor) * throwforce;
                CharMo.MoveSpd = 15;

            }
            else
            {
                grabChk = false;
                CharMo.MoveSpd = 15;
            }
            if (grabChk == true)
            {
                CharMo.MoveSpd = 15;
                CharMo.JumpFrc = 15;
            }
            
        }
        animator.SetBool("GRB", grabChk);
        animator.SetBool("HLD", isHeld);
    }

}

/*RaycastHit2D grabbed = Physics2D.Raycast(grabObj.position, Vector2.right * transform.localScale, ray);
if (grabbed.collider != null && grabbed.collider.tag == "NPC")
{
    if (Input.GetKey(KeyCode.Q))
    {
        grabbed.collider.gameObject.transform.parent = NpcHold;
        grabbed.collider.gameObject.transform.position = NpcHold.position;
        grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        isHeld = true;
    }
    else
    {
        //grabbed.collider.gameObject.transform.parent = null;
        //grabbed.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        if (grabbed.collider.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            grabbed.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.5f) * Speed;
        }
    }

}*/