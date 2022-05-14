using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    Rigidbody2D npcRigidbody;
    CapsuleCollider2D npcCollider;
    bool isTriggered = false;
    [SerializeField] GameObject item;


    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody2D>();
        npcCollider = GetComponent<CapsuleCollider2D>();
        npcRigidbody.gravityScale = 0;
        if(item!=null) item.SetActive(false);
    }

    private void Update()
    {
        if (isTriggered)
        {
           if(Input.GetKeyDown(KeyCode.F))
                if (item != null) item.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            npcRigidbody.gravityScale = 0;
            npcCollider.isTrigger = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
        }
    }

    public float GetGravity() { return npcRigidbody.gravityScale; }
    public void SetGravity(float scale) { npcRigidbody.gravityScale = scale; }
}
