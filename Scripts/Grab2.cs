using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab2 : MonoBehaviour
{
    public Transform grabDetect;//Grab Detector
    public Transform NpcHold;// NPC Holder Point
    public bool grabChk = true;//Check to see if an NPC is grabbed
    public float ray;// Ray for the raycast
    public float throwforce;//Force in X direction
    public float upFor;//Force in Y direction
    CharacterMovement CharMo;//Class CharacterMovement for Jump Force and Character Movement
    // Start is called before the first frame update
    void Start()
    {
        CharMo = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        var movement = Input.GetAxis("Horizontal");//movement for throw
        
        if (collision != null && collision.tag == "NPC")
        {
            if (Input.GetKey(KeyCode.Q)) //&& CharMo.runChek == false)
            {
                grabChk = true;
                collision.gameObject.transform.parent = NpcHold;
                collision.gameObject.transform.position = NpcHold.position;
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            }
            else
            {
                grabChk = false;
                collision.gameObject.transform.parent = null;
                collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
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
                //collision.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, upFor) * throwforce;
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
                collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, upFor) * throwforce;

            }
            else
            {
                grabChk = false;
                CharMo.MoveSpd = 15;
            }
            if (grabChk == true)
            {
                CharMo.MoveSpd = 0;
                CharMo.JumpFrc = 0;
            }
            else
            {
                CharMo.JumpFrc = 15;
            }

        }
        if (collision.tag == "NPC")
        {
            grabChk = true;
        }
    }
}
