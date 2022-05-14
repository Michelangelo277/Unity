using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCbev : MonoBehaviour
{
    public Animator animator;//for player animations
    Grab lr;// sets status is grabbed for movement speed
    public bool isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
                animator.SetBool("NGB", true);
        }else
        {
                animator.SetBool("NGB", false);
        }
    }
}
