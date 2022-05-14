using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricScanner : MonoBehaviour
{
    [SerializeField] GameObject electricWallReference;
    [SerializeField] GameObject screen;
    [SerializeField] GameObject screenLight;
    private bool isTriggered = false;
    private AudioSource scannerSound;
    private bool soundHasPlayed = false;

    // Start is called before the first frame update
    void Awake()
    {
        scannerSound = GetComponent<AudioSource>();
        scannerSound.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (electricWallReference != null) Destroy(electricWallReference);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC"))
        {
            //Give negative feedback
        }

        if (collision.gameObject.CompareTag("NPC2"))
        {
            isTriggered = true;
            if(screen!=null)screen.GetComponent<SpriteRenderer>().color = Color.green;
            if(screenLight != null)screenLight.GetComponent<Light>().color = Color.green;

            if (!soundHasPlayed)
            {
                scannerSound.Play();
                soundHasPlayed = true;
            }
        }
    }
}
