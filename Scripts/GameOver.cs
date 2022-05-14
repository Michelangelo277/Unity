using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static CharacterMovement;
public class GameOver : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject ContinueButton;
    public GameObject MainMenu;
    CharacterMovement CharMo;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showGameOverPanel()
    {
        if (CharMo.healthVal <= 0)
        {
            
            GameOverPanel.SetActive(true);
        }

        if (CharMo.healthVal >= 0)
        {
            GameOverPanel.SetActive(false);
        }
    }
 
   

}
