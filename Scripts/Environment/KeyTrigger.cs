using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    [SerializeField] DoorTrigger doorReference1;
    [SerializeField] DoorTrigger doorReference2;
    [SerializeField] GameObject accessSprite;
    [SerializeField] GameObject noAccessSprite;
    [SerializeField] GameObject keySprite;

    bool playerIsDetected;

    private AudioSource grabbedSound;
    private BoxCollider2D boxCollider;

    private bool isTriggered;
    private float soundTimeStart = 1f;
    private float soundTimer;

    //[SerializeField] GameObject keyTxt;


    // Start is called before the first frame update
    void Awake()
    {
        //Set defaults
        playerIsDetected = false;
        if (accessSprite != null) accessSprite.SetActive(false);
        if (noAccessSprite != null) noAccessSprite.SetActive(true);
        grabbedSound = GetComponent<AudioSource>();
        grabbedSound.Stop();
        boxCollider = GetComponent<BoxCollider2D>();

        soundTimer = soundTimeStart;
        isTriggered = false;
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
                if(doorReference1 != null) doorReference1.DisableLock(true);
                if (doorReference2 != null) doorReference2.DisableLock(true);

                if(accessSprite != null) accessSprite.SetActive(true);
                if (noAccessSprite != null) noAccessSprite.SetActive(false);
                playerIsDetected = false;
                grabbedSound.Play();
                isTriggered = true;
            }
        }

        if (isTriggered)
        {
            //Disable key while allowing sound to play
            soundTimer -= 1 * Time.deltaTime;
            boxCollider.enabled = false;
            keySprite.SetActive(false);
            
            if(soundTimer <= 0 ) Destroy(this.gameObject);
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
            //keyTxt.SetActive(false);
        }
    }
}
