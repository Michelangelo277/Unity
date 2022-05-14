/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Transform positionToTravel;
    //[SerializeField] GameObject keyTxt;
    public float yTravelOffset;

    public bool isLocked;

    bool playerIsDetected;
    GameObject playerGameObject;
    BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        playerIsDetected = false;
        boxCollider = GetComponent<BoxCollider2D>();

        if (isLocked)
        {
            boxCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDetected)
        {
            //keyTxt.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                playerGameObject.transform.position = new Vector3(
                    positionToTravel.position.x,
                    positionToTravel.position.y + yTravelOffset,
                    0
                    );
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsDetected = true;
            playerGameObject = collision.gameObject;
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

    public void SetColliderActive(bool status)
    {
        boxCollider.enabled = status;
    }
}
}
}
*/
