using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CharacterMovement;

public class staminaController : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float playerStamina = 100.0f;
    [SerializeField] private float maxStamina = 100.0f;
    [SerializeField] private float jumpCost = 20;
    [HideInInspector] public bool hasRegenerated = true;
    [HideInInspector] public bool weAreSprinting = false;

    [Header("Stamina Regen Parameters")]
    [SerializeField] private float staminaDrain = 0.5f;
    [SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina Speed Paramters")]
    [SerializeField] private int slowRunSpeed = 4;
    [SerializeField] private int normalRunSpeed = 8;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderecanvasGroup = null;

    private void update()
    {
        if (!weAreSprinting)
        {
            if (playerStamina <= maxStamina - 0.01)
            {
                playerStamina += staminaRegen * Time.deltaTime;
                //UpdateStamina
                UpdateStamina(1);
                if (playerStamina >= maxStamina)
                {
                    //set to normal speed
                    sliderecanvasGroup.alpha = 0;
                    hasRegenerated = true;
                }

            }

        }
    }
    public void Sprinting()
    {
        if(hasRegenerated)
        {
            weAreSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);
            
            if(playerStamina <= 0)
            {
                hasRegenerated = false;
                //slow the player
                sliderecanvasGroup.alpha = 0;
            }
        }
    }
    public void staminaJump()
    {
        if(playerStamina >= (maxStamina * jumpCost / maxStamina))
        {
            playerStamina -= jumpCost;
            //allow player to jump
            UpdateStamina(1);
        }
    }
    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = playerStamina / maxStamina;

        if(value == 0)
        {
            sliderecanvasGroup.alpha = 0;
        }
        else
        {
            sliderecanvasGroup.alpha = 1;
        }
    }
}
