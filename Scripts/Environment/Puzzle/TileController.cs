using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    private int value;

    private void Start()
    {
        value = -1;
    }

    public void ChangeColor()
    {
        value *= -1;
        if(value < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    public int GetValue() { return value; }
}
