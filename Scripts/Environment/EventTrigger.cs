using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{

    [SerializeField] GameObject targetObject;

    // Start is called before the first frame update
    void Awake()
    {
        targetObject.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            targetObject.gameObject.SetActive(true);
        }
    }
}
