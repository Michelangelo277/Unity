using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerTrigger : MonoBehaviour
{
    bool isActive;
    bool playerIsDetected;
    [SerializeField] GameObject powerSprite;
    [SerializeField] GameObject nopowerSprite;
    [SerializeField] GameObject buttons;
    private AudioSource buttonSound;
    bool soundHasPlayed = false;


    void Awake()
    {
        isActive = false;
        playerIsDetected = false;
        powerSprite.SetActive(false);
        nopowerSprite.SetActive(true);
        buttonSound = GetComponent<AudioSource>();
        buttonSound.Stop();
    }

    private void Update()
    {
        if (playerIsDetected)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isActive = true;
                powerSprite.SetActive(true);
                nopowerSprite.SetActive(false);
                buttons.GetComponent<SpriteRenderer>().color = Color.cyan;
                if (!soundHasPlayed)
                {
                    buttonSound.Play();
                    soundHasPlayed = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerIsDetected = false;
        }
    }

    public bool IsActivated() { return isActive; }
}
