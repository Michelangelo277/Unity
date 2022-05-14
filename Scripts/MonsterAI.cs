using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] private float attackDamage = 10f;
    [SerializeField] private float attackSpeed = 1f;
    private float monAttack;
    public float speed = 3f;
    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }

    private void OnCollisionStay2D(Collision2D obj)
    {
        if (obj.gameObject.CompareTag("Player"))
        {
            if (attackSpeed <= monAttack)
            {
                obj.gameObject.GetComponent<CharacterMovement>().UpdateHealth(-attackDamage);
                monAttack = 0f;
            }
            else
            {
                monAttack += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            target = obj.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.gameObject.CompareTag("Player"))
        {
            target = null;
        }
    }

    // Start is called before the first frame update
    /*void Start()
    {
        
    }*/
}
