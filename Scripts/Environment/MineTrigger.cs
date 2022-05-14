using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTrigger : MonoBehaviour
{
    private bool isTriggered = false;
    private bool canExplode = true;

    [SerializeField] ParticleSystem explosion;
    [SerializeField] GameObject explosionHitbox;
    [SerializeField] GameObject mineObject;
    private AudioSource explodeSound;

    private float blastTimeStart = 1.0f;
    private float blastTimer;


    // Start is called before the first frame update
    void Start()
    {
        explosion.Stop();
        explosionHitbox.SetActive(false);
        explodeSound = GetComponent<AudioSource>();
        blastTimer = blastTimeStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC") || collision.gameObject.CompareTag("NPC2") || collision.gameObject.CompareTag("Enemy"))
        {
            isTriggered = true;
            if(collision.gameObject.CompareTag("NPC")) Destroy(collision.gameObject);
            if (collision.gameObject.CompareTag("NPC2")) Destroy(collision.gameObject);
        }
    }

    private void Explode()
    {
        blastTimer -= 1 * Time.deltaTime;

        if (blastTimer < 0)
        {
            explosion.Stop();
            explosionHitbox.SetActive(false);

            if (blastTimer < -2)
            {
                Destroy(explosion);
                Destroy(explosionHitbox);
                Destroy(this.gameObject);
            }
        }
        else
        {
            explosion.Play();
            explosionHitbox.SetActive(true);
            Destroy(mineObject);
        }

        if (canExplode)
        {
            explodeSound.Play();
            canExplode = false;
        }
    }
}
