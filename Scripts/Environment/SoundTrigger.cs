using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    AudioSource soundSource;

    bool soundHasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();
        soundSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        soundSource.loop = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!soundHasPlayed)
        {
            soundSource.Play();
            soundHasPlayed = true;
        }
    }
}
