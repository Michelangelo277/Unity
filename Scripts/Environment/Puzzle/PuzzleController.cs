using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    [SerializeField] List<ButtonTrigger> buttons  = new List<ButtonTrigger>();
    [SerializeField] List<TileController> tiles = new List<TileController>();
    [SerializeField] GameObject confirmScreen;
    [SerializeField] GameObject confirmLight;
    [SerializeField] GameObject targetObject;
    private AudioSource audioSource;
    private AudioClip onSound, offSound;
    bool success = false;
    
    //Flags to control sound cues
    bool screenState = false;
    bool soundCanPlay = false;
    bool screenIsOn = false;

    //Armory Variables
    [SerializeField] GameObject targetDoor;
    [SerializeField] GameObject powerSprite;
    [SerializeField] GameObject noPowerSprite;
    [SerializeField] GameObject panelPowerSprite;
    [SerializeField] GameObject panelNoPowerSprite;


    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        onSound = Resources.Load<AudioClip>("Sounds/ComputerOn");
        offSound = Resources.Load<AudioClip>("Sounds/ComputerOff");
        if (targetDoor != null) targetDoor.SetActive(false);

        if (powerSprite !=  null) powerSprite.SetActive(false);
        if (noPowerSprite != null) noPowerSprite.SetActive(true);

        if (panelPowerSprite != null) panelPowerSprite.SetActive(false);
        if (panelNoPowerSprite != null) panelNoPowerSprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (ButtonTrigger button in buttons){
            if (button.hasChanged)
            {
                switch (button.ID())
                {
                    case 1:
                        tiles[1].ChangeColor();
                        break;
                    case 2:
                        tiles[0].ChangeColor();
                        tiles[3].ChangeColor();
                        break;
                    case 3:
                        tiles[0].ChangeColor();
                        tiles[1].ChangeColor();
                        tiles[2].ChangeColor();
                        break;
                    case 4:
                        tiles[1].ChangeColor();
                        tiles[3].ChangeColor();
                        break;
                    default:
                        break;
                }
                soundCanPlay = true;
                button.hasChanged = false;
            }
        }



        success = true;
        foreach (TileController tile in tiles)
        {
            if(tile.GetValue() < 0)
            {
                success = false;
            }
        }

        if (success) {
            confirmScreen.GetComponent<SpriteRenderer>().color = Color.green;
            confirmLight.GetComponent<Light>().color = Color.green;
            if(targetObject != null) targetObject.SetActive(false);
            screenIsOn = true;
            if (targetDoor != null) targetDoor.SetActive(true);

            //Toggle Power Display
            if (powerSprite != null) powerSprite.SetActive(true);
            if (noPowerSprite != null) noPowerSprite.SetActive(false);
            if (panelPowerSprite != null) panelPowerSprite.SetActive(true);
            if (panelNoPowerSprite != null) panelNoPowerSprite.SetActive(false);

        }
        else
        {
            confirmScreen.GetComponent<SpriteRenderer>().color = Color.red;
            confirmLight.GetComponent<Light>().color = Color.red;
            if (targetObject != null) targetObject.SetActive(true);
            screenIsOn = false;
            if (targetDoor != null) targetDoor.SetActive(false);

            //Toggle Power Display
            if (powerSprite != null) powerSprite.SetActive(false);
            if (noPowerSprite != null) noPowerSprite.SetActive(true);
            if (panelPowerSprite != null) panelPowerSprite.SetActive(false);
            if (panelNoPowerSprite != null) panelNoPowerSprite.SetActive(true);
        }

        if (soundCanPlay && (screenState!=screenIsOn))
        {
            if (screenIsOn)
            {
                audioSource.PlayOneShot(onSound);
                soundCanPlay = false;
            }
            else
            {
                audioSource.PlayOneShot(offSound);
                soundCanPlay = false;
            }
            screenState = screenIsOn;
        }

    }
}
