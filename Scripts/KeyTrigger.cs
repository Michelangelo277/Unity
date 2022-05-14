/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] DoorTrigger doorReference1;
    [SerializeField] DoorTrigger doorReference2;

    [SerializeField] GameObject keyTxt;

    bool playerIsDetected;

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
            keyTxt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                keyTxt.SetActive(false);
                doorReference1.SetColliderActive(true);
                doorReference2.SetColliderActive(true);
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
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsDetected = false;
            keyTxt.SetActive(false);
        }
    }
}*/
