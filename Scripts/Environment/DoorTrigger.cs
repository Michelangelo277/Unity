using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Transform positionToTravel;
    //[SerializeField] GameObject keyTxt;
    public float yTravelOffset;
    public bool isLocked;

    //Door Transition variables
    bool playerIsDetected;
    bool isTransitioning = false;
    bool hasTeleported = false;
    private float startingTime = 1f;
    private float timer;
    GameObject playerGameObject;
    BoxCollider2D boxCollider;
    CharacterMovement moveScript;
    GameObject mainCam;
    CameraFade fadeScript;

    //Door Destruction variables
    public bool isDestructable;
    [SerializeField] GameObject bombObject;
    [SerializeField] GameObject doorObject;
    private bool isExploding = false;
    private float fuseTimeStart = 1f;
    private float fuseTimer;
    GrenadeInteraction grenadeScript;
    
    //Explosion variables
    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject hurtBox;
    private float duration;

    //Audio variables
    public bool hasSound = true;
    private bool soundHasPlayed = false;
    private AudioSource doorSounds;
    private AudioClip openClip;
    private AudioClip explosionClip;

    //Video variables
    public bool isElevator = false;
    [SerializeField] GameObject videoPlayer;
    private float videoTimeStart = 12f;
    private float videoTimer;


    // Start is called before the first frame update
    void Awake()
    {
        //Set defaults and Get object & script references
        playerIsDetected = false;
        boxCollider = GetComponent<BoxCollider2D>();

        mainCam = GameObject.FindGameObjectWithTag("MainCamera");
        fadeScript = mainCam.GetComponent<CameraFade>();
        timer = startingTime;

        fuseTimer = fuseTimeStart;
        if(bombObject != null) bombObject.SetActive(false);


        if (explosion != null)
        {
            explosion = GetComponent<ParticleSystem>();
            explosion.Stop();

        }

        if (hurtBox!=null) hurtBox.SetActive(false);

        //Enable/Disable collider based on flags
        if (!isLocked)
        {
            boxCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = false;
        }

        
        doorSounds = GetComponent<AudioSource>();
        openClip = Resources.Load<AudioClip>("Sounds/DoorOpenSound");
        explosionClip = Resources.Load<AudioClip>("Sounds/Explosion");

        videoTimer = videoTimeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsDetected && playerGameObject.GetComponent<CharacterMovement>().CanAct())
        {
            //keyTxt.SetActive(true);
         
            if (!isLocked && !isDestructable)
            {
                if (Input.GetKeyDown(KeyCode.F) && !isTransitioning)
                {
                    isTransitioning = true;                 //Flag Transition Event
                    moveScript.EnableMovement(false);       //Disable Player Input
                    fadeScript.StartFadeScreen();           //Start Screen Fade
                                                            //TODO Move Door
                }
            }
            else if(isDestructable && !isExploding)
            {
                if (Input.GetKeyDown(KeyCode.F) && grenadeScript.CheckGrenade())
                {
                    isExploding = true;
                    grenadeScript.EnableGrenade(false);
                    if (bombObject != null) bombObject.SetActive(true);
                }
            }
        }

        //If events are flagged
        if (isTransitioning)
        {
            if (positionToTravel != null)
            {
                if (isElevator)
                {
                    RunElevator();
                }
                else
                {
                    RunTransition();
                }
            }
        }

        if (isExploding)
        {
            RunExplosion();
        }
        else
        {
            if (explosion != null) { 
                duration -= 1 * Time.deltaTime;
                if (duration <= 0)
                {
                    duration = startingTime;
                    explosion.Stop();
                    hurtBox.SetActive(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsDetected = true;
            playerGameObject = collision.gameObject;
            moveScript = playerGameObject.GetComponent<CharacterMovement>();
            grenadeScript = playerGameObject.GetComponent<GrenadeInteraction>();
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

    public void DisableLock(bool flag)
    {
        isLocked = !flag;
        boxCollider.enabled = flag;
    }

    private void RunTransition()
    {
        if (hasSound && !soundHasPlayed)
        {
            doorSounds.PlayOneShot(openClip);
            soundHasPlayed = true;
        }
        

        //Start timer
        timer -= 1 * Time.deltaTime;

        //If 1/2 time, telport player once
        if (timer <= startingTime / 2 && !hasTeleported)
        {
            playerGameObject.transform.position = new Vector3(
            positionToTravel.position.x,
            positionToTravel.position.y + yTravelOffset,
            0
            );

            hasTeleported = true;
        }

        //If no time remains
        if (timer <= 0)
        {
            //Reset values
            moveScript.EnableMovement(true);
            isTransitioning = false;
            timer = startingTime;
            hasTeleported = false;
            soundHasPlayed = false;
        }
    }

    private void RunElevator()
    {
        //Play sound
        if (hasSound && !soundHasPlayed)
        {
            doorSounds.PlayOneShot(openClip);
            soundHasPlayed = true;
        }

        //Play video
        if (videoPlayer != null) videoPlayer.SetActive(true);

        //Start timer
        videoTimer -= 1 * Time.deltaTime;

        //If 1/2 time, telport player once
        if (videoTimer <= videoTimeStart / 2 && !hasTeleported)
        {
            playerGameObject.transform.position = new Vector3(
            positionToTravel.position.x,
            positionToTravel.position.y + yTravelOffset,
            0
            );

            hasTeleported = true;
        }

        //If no time remains
        if (videoTimer <= 0)
        {
            //Reset values
            moveScript.EnableMovement(true);
            isTransitioning = false;
            videoTimer = videoTimeStart;
            hasTeleported = false;
            soundHasPlayed = false;
            if (videoPlayer != null) videoPlayer.SetActive(false);
        }
    }

    private void RunExplosion() 
    {
        //Start fuse timer
        fuseTimer -= 1 * Time.deltaTime;

        if(fuseTimer <= 0)
        {
            Explode();
            if (doorObject != null) Destroy(doorObject);
            if (bombObject != null) Destroy(bombObject);
            DisableLock(false);
            isDestructable = false;
            isExploding = false;
        }

    }

    void Explode() {
        explosion.Play();
        doorSounds.PlayOneShot(explosionClip);
        hurtBox.SetActive(true);
    }

    public void Transport(GameObject target)
    {
        target.transform.position = new Vector3(
                positionToTravel.position.x,
                positionToTravel.position.y + yTravelOffset,
                0
                );
    }
}
