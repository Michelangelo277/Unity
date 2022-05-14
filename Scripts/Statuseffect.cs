using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterMovement;


public class Statuseffect : MonoBehaviour
{
    CharacterMovement CharMo;
 
    public GameObject Canvas;
    public float batteryLevel = 100;
    public GameObject Health;
    public GameObject Stamina;
    public GameObject flashlight;

    void Start()
    {
        CharMo = GetComponent<CharacterMovement>();
      
    }
    void Update()
    {
        //This updates the health status's color based on its current value
        if (CharMo.healthVal >= 100)
        {
            Health.GetComponent<Image>().color = new Color32(152, 0, 0, 255);
        }
        if (CharMo.healthVal <= 75)
        {
            Health.GetComponent<Image>().color = new Color32(140, 255, 255, 255);
        }
        if (CharMo.healthVal <= 50)
        {
            Health.GetComponent<Image>().color = new Color32(243, 255, 23, 255);
        }
        if (CharMo.healthVal <= 25)
        {
            Health.GetComponent<Image>().color = new Color32(255, 92, 23, 255);
        }

        //This updates the stamina bar color based on it's current status
        if (CharMo.playerStamina >= 100.0)
        {
            Stamina.GetComponent<Image>().color = new Color32(27, 138, 14, 255);
        }
        if (CharMo.playerStamina <= 50.0)
        {
            Stamina.GetComponent<Image>().color = new Color32(190, 178, 30, 255);
        }
        if (CharMo.playerStamina <= 25.0)
        {
            Stamina.GetComponent<Image>().color = new Color32(255, 4, 37, 255);
            CharMo.MoveSpd = 5; //you are exhausted
        }
        if (CharMo.playerStamina <= 0.0)
        {
            Stamina.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
            CharMo.MoveSpd = 0; //you need to rest and regen
        }
        //This updates the flash light
        if (batteryLevel >= 100)
        {
            flashlight.GetComponent<Image>().color = new Color32(255, 239, 0, 255);
        }
        if (batteryLevel <= 75)
        {
            flashlight.GetComponent<Image>().color = new Color32(255, 239, 0, 200);
        }
        if (batteryLevel <= 50)
        {
            flashlight.GetComponent<Image>().color = new Color32(255, 239, 0, 100);
        }
        if (batteryLevel <= 25)
        {
            flashlight.GetComponent<Image>().color = new Color32(255, 239, 0, 50);
        }
        //This toggles the hud via hotkey
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Canvas.gameObject.SetActive(!Canvas.gameObject.activeSelf);
        }
    }
}