using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    //Trigger variables
    [SerializeField] Transform destination;
    Vector2 direction;
    bool isTriggered = false;

    //Bullet variables
    public GameObject bullet;
    [SerializeField] float fireRate;
    float nextTimetoShoot = 0;
    public float force;

    //LightVariables
    [SerializeField] GameObject triggerLight;
    [SerializeField] GameObject laser;
    float laserTime = 0.7f;
    float timer;
    bool hasShot = false;

    //Sound Variables
    private AudioSource gunSounds;

    // Start is called before the first frame update
    void Awake()
    {
        timer = laserTime;
        gunSounds = GetComponent<AudioSource>();
        gunSounds.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        direction = (Vector2)destination.position - (Vector2)transform.position;

        if (isTriggered)
        {
            triggerLight.GetComponent<SpriteRenderer>().color = Color.red;

            if(Time.time > nextTimetoShoot)
            {
                nextTimetoShoot = Time.time + 1/fireRate;
                Shoot();
                hasShot = true;
            }
        }
        else
        {
            triggerLight.GetComponent<SpriteRenderer>().color = Color.green;
        }

        if (hasShot)
        {
            //Disable/Enable laser
            laser.SetActive(false);
            timer -= 1 * Time.deltaTime;
            if(timer <= 0)
            {
                laser.SetActive(true);
                hasShot = false;
                timer = laserTime;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("NPC"))
        {
            isTriggered = false;
        }
    }

    private void Shoot()
    {
        GameObject bulletsInstances = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletsInstances.GetComponent<Rigidbody2D>().AddForce(direction * force);
        gunSounds.Play();
    }
}


