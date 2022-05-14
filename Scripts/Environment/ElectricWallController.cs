using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWallController : MonoBehaviour
{
    private bool isTriggered = false;
    private AudioSource electricWallSounds;
    private AudioClip breakSound;
    private float destroyTimeStart = 1f;
    private float destroyTimer;
    private bool soundHasPlayed = false;
    [SerializeField] private GameObject buzzAudio;

    // Start is called before the first frame update
    void Awake()
    {
        electricWallSounds = GetComponent<AudioSource>();
        //buzzSound = Resources.Load<AudioClip>("Sounds/ElectricDoorBuzz");
        breakSound = Resources.Load<AudioClip>("Sounds/ElectricDoorBreaks");
        destroyTimer = destroyTimeStart;
    }

    // Update is called once per frame
    void Update()
    {

        if (isTriggered)
        {
            destroyTimer -= 1 * Time.deltaTime;
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            if (!soundHasPlayed)
            {
                electricWallSounds.PlayOneShot(breakSound);
                buzzAudio.SetActive(false);
                soundHasPlayed = true;
            }

            if (destroyTimer <= 0) Destroy(this.gameObject);
        }
        else
        {
            //electricWallSounds.PlayOneShot(buzzSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC"))
        {
            isTriggered = true;
            if (collision.gameObject.CompareTag("NPC")){
                Destroy(collision.gameObject);
            }
        }
    }
}
