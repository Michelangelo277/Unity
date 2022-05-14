using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoints : MonoBehaviour
{
    private GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameMaster>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("CheckPointTriggred!");
            gm.lastCheckPointPos = transform.position;
        }
    }
}
