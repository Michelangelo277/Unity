using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadPrefs : MonoBehaviour
{
    [Header("General setting")]
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuController menuController;

    [Header("Volume Setting")]
    [SerializeField] private TMP_Text volumeTextvalue = null;
    [SerializeField] private Slider volumeSlider = null;

    [Header("Brightness Setting")]
    [SerializeField] private Slider brightnessSldier = null;
    [SerializeField] private TMP_Text BrightnessTextValue = null;

    [Header("Quality Level Setting")]
    [SerializeField] private TMP_Dropdown qualityDropdown;

    [Header("Fullscreen Setting")]
    [SerializeField] private Toggle fullScreenToggle;

    [Header("sensitivity Setting")]
    [SerializeField] private TMP_Text controllerSenTextValue = null;
    [SerializeField] private Slider controllerSenSlider = null;

    [Header("Invert Y Setting")]
    [SerializeField]
    private Toggle invertYToggle = null;
    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                volumeTextvalue.text = localVolume.ToString("0.0");
                volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                menuController.ResetButon("Audio");
            }

            if (PlayerPrefs.HasKey("masterQuality"))
            {
                int localQuality = PlayerPrefs.GetInt("masterQuality");
                qualityDropdown.value = localQuality;
                QualitySettings.SetQualityLevel(localQuality);
            }

            if (PlayerPrefs.HasKey("masterFullscreen"))
            {
                int localFullscreen = PlayerPrefs.GetInt("masterFullscreen");

                if (localFullscreen == 1)
                {
                    Screen.fullScreen = true;
                    fullScreenToggle.isOn = true;
                }
                else
                {
                    Screen.fullScreen = false;
                    fullScreenToggle.isOn = false;
                }
            }

            if (PlayerPrefs.HasKey("masterBrightness"))
            {
                float localBrightness = PlayerPrefs.GetFloat("masterBrightness");

                BrightnessTextValue.text = localBrightness.ToString("0.0");
                brightnessSldier.value = localBrightness;
            }

            if (PlayerPrefs.HasKey("masterSensitivity"))
            {
                float localsensitivity = PlayerPrefs.GetFloat("masterSensitivity");

                controllerSenTextValue.text = localsensitivity.ToString("0");
                controllerSenSlider.value = localsensitivity;
                menuController.mainControllerSen = Mathf.RoundToInt(localsensitivity);
            }

            if (PlayerPrefs.HasKey("masterInvertY"))
            {


                if (PlayerPrefs.GetInt("masterInvertY") == 1) 
                {
                    invertYToggle.isOn = true;
                }

                else
                {
                    invertYToggle.isOn = false;
                }
                
            }
        }
    }
}
