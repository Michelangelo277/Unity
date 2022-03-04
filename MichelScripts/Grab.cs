using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public Transform grabObjR;
    public Transform NpcHoldR;
    public Transform grabObjL;
    public Transform NpcHoldL;
    public float ray;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D grabbedR = Physics2D.Raycast(grabObjR.position, Vector2.right * transform.localScale, ray);
        RaycastHit2D grabbedL = Physics2D.Raycast(grabObjL.position, Vector2.left * transform.localScale, ray);
        if (grabbedR.collider != null && grabbedR.collider.tag == "NPC")
        {
            if (Input.GetKey(KeyCode.Q)) {
                grabbedR.collider.gameObject.transform.parent = NpcHoldR;
                grabbedR.collider.gameObject.transform.position = NpcHoldR.position;
                grabbedR.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

}
            else 
            {
                grabbedR.collider.gameObject.transform.parent = null;
                grabbedR.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }

        if (grabbedL.collider != null && grabbedL.collider.tag == "NPC")
        {
            if (Input.GetKey(KeyCode.Q))
            {
                grabbedL.collider.gameObject.transform.parent = NpcHoldL;
                grabbedL.collider.gameObject.transform.position = NpcHoldL.position;
                grabbedL.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            else
            {
                grabbedL.collider.gameObject.transform.parent = null;
                grabbedL.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;

            }
        }


    }

}
