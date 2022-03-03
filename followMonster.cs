using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followMonster : MonoBehaviour
{
    public Transform target;

    public float speed = 2;

    public float minimumDistance;



    

    // Update is called once per frame
    void Update()
    {
      if (Vector2.Distance(transform.position, target.position) > minimumDistance){
      transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
      }

    }
}
