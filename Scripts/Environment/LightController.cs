using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] GameObject targetLight;
    public bool willBreak;
    bool isBroken;
    public bool isFlashing;
    public float flashTime;
    float flashTimer;
    bool enableLight;



    // Start is called before the first frame update
    void Start()
    {
        flashTimer = flashTime;
        enableLight = true;
        isBroken = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFlashing && targetLight!=null && !isBroken)
        {
            flashTimer -= 1 * Time.deltaTime;
            if(flashTimer <= 0)
            {
                flashTimer = flashTime;
                enableLight = !enableLight;
                targetLight.SetActive(enableLight);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (willBreak)
            {
                if (targetLight != null)
                {
                    targetLight.SetActive(false);
                    isBroken = true;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
}
