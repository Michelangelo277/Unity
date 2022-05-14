using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrigger : MonoBehaviour
{
    [SerializeField] GameObject fallingObject;
    public float gravityScale;
    bool canFall = true;
    bool hasSound = false;
    private AudioSource scarySound;
    private bool soundHasPlayed = false;

    private void Awake()
    {
        scarySound = GetComponent<AudioSource>();
        scarySound.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && canFall)
        {
            fallingObject.GetComponent<FallingObject>().SetGravity(gravityScale);
            canFall = false;
            if (!soundHasPlayed)
            {
                scarySound.Play();
                soundHasPlayed = true;
            }
        }
    }
}
