using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSoundManager : MonoBehaviour
{
    AudioSource worldSound;

    // Start is called before the first frame update
    void Start()
    {
        worldSound = GetComponent<AudioSource>();
        worldSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        worldSound.loop = true;
    }
}
