using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitfallTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Collider2D>().isTrigger = true;
            collision.GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.GetComponent<Collider2D>().isTrigger = false;
            collision.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
    }
}
