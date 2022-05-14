using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeTrigger : MonoBehaviour
{
    //[SerializeField] GameObject keyTxt;


    bool playerIsDetected;
    GrenadeInteraction playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerIsDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDetected)
        {
            //keyTxt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                //keyTxt.SetActive(false);
                playerScript.EnableGrenade(true);
                playerIsDetected = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsDetected = true;
            playerScript = collision.GetComponent<GrenadeInteraction>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsDetected = false;
            //keyTxt.SetActive(false);
        }
    }
}
