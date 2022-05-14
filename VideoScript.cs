using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScript : MonoBehaviour
{

    VideoPlayer video;

    void Start()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        StartCoroutine("WaitForMovieEnd");
    }


    public IEnumerator WaitForMovieEnd()
    {
        while (video.isPlaying)
        {
            yield return new WaitForEndOfFrame();

        }
        OnMovieEnded();
    }

    void OnMovieEnded()
    {
        gameObject.GetComponent("Credits");
        
    }
}