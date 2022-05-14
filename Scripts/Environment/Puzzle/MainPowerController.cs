using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPowerController : MonoBehaviour
{
    [SerializeField] List<PowerTrigger> powerTriggers = new List<PowerTrigger>();
    [SerializeField] DoorTrigger targetDoor;
    [SerializeField] GameObject accessSprite;
    [SerializeField] GameObject noAccessSprite;
    bool success = false;
    bool isActive = false;

    private void Awake()
    {
        accessSprite.SetActive(false);
        noAccessSprite.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive)
        {
            success = true;
            foreach (PowerTrigger trigger in powerTriggers)
            {
                if (!trigger.IsActivated())
                {
                    success = false;
                }
            }

            if (success)
            {
                targetDoor.DisableLock(true);
                isActive = true;
                accessSprite.SetActive(true);
                noAccessSprite.SetActive(false);
            }
        }
    }
}
