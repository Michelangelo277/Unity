using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] GameObject targetObject;

    private void Awake()
    {
        if(targetObject != null) targetObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (targetObject != null) targetObject.SetActive(true);
        }
    }
}
