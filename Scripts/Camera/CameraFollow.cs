using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;

    [SerializeField]
    float minX, minY, maxX, maxY;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //store current camera pos
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        temp.y = playerTransform.position.y;

        if(temp.x < minX) temp.x = minX;
        if(temp.y < minY) temp.y = minY;
        if(temp.x > maxX) temp.x = maxX;
        if(temp.y > maxY) temp.y = maxY;

        transform.position = temp;


    }

    public void SetConfiners(Transform topRight, Transform bottomLeft)
    {
        maxX = topRight.position.x;
        maxY = topRight.position.y;
        minX = bottomLeft.position.x;
        minY = bottomLeft.position.y;
    }
}
