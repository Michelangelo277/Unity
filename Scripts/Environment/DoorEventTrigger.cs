using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEventTrigger : MonoBehaviour
{
    [SerializeField] GameObject npc;
    [SerializeField] GameObject door;
    [SerializeField] GameObject doorFallen;
    bool canActivate = true;
    public float force;

    private AudioSource doorSound;
    private bool soundHasPlayed;
    private float eventTime = 0.2f;
    private float eventTimer;

    bool isTriggered = false;

    private void Start()
    {
        npc.SetActive(false);
        door.SetActive(true);
        doorFallen.SetActive(false);
        doorSound = GetComponent<AudioSource>();
        doorSound.Stop();
        eventTimer = eventTime;
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (!soundHasPlayed)
            {
                doorSound.Play();
                soundHasPlayed = true;
            }

            eventTime -= Time.deltaTime;


            if (eventTime < 0)
            {
                ActivateEvent();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canActivate)
        {
            isTriggered = true;

            

        }
    }

    private void ActivateEvent()
    {
        if (canActivate)
        {
            canActivate = false;
            npc.SetActive(true);
            npc.GetComponent<FallingObject>().SetGravity(10);
            npc.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * force);
            door.SetActive(false);
            doorFallen.SetActive(true);
        }
    }
}
