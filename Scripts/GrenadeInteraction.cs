using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeInteraction : MonoBehaviour
{
    private bool playerHasGrenade = false;

    public void EnableGrenade(bool flag) 
    {
        playerHasGrenade = flag;
    }

    public bool CheckGrenade() 
    {
        return playerHasGrenade;
    }
}
