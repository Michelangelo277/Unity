using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    private int value;
    [SerializeField] private int buttonID;
    [SerializeField] private GameObject buttonLight;
    bool isTriggered = false;
    public bool hasChanged = false;
    private AudioSource buttonSound;

    // Start is called before the first frame update
    private void Start()
    {
        value = -1;
        buttonSound = GetComponent<AudioSource>();
        buttonSound.Stop();
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                buttonSound.Play();
                value *= -1;
                hasChanged = true;
                if(value > 0)
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
                    buttonLight.GetComponent<Light>().color = Color.cyan;
                  
                }
                else
                {
                    this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                    buttonLight.GetComponent<Light>().color = Color.white;
                }
            }
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

    public int Value() { return value; }

    public int ID() { return buttonID;}

}
