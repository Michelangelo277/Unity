using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] GameObject cutscene;
    private CharacterMovement playerMoveScript;
    private GameObject playerObject;
    bool isTriggered = false;
    public float sceneTimeStart;
    private float sceneTimer;
    public bool canReplay = false;

    public bool enablePostSceneObject;
    [SerializeField] GameObject postSceneObject;
    public bool enablePostSceneObject2;
    [SerializeField] GameObject postSceneObject2;
    [SerializeField] Transform postPlayerPosition;

    private CameraFade fadeScript;
    private bool hasFadedStart = false;
    private bool hasFadedEnd = false;

    // Start is called before the first frame update
    void Awake()
    {
        sceneTimer = sceneTimeStart;
        cutscene.SetActive(false);
        fadeScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFade>();
        if (postSceneObject != null) postSceneObject.SetActive(false);
        if (postSceneObject2 != null) postSceneObject2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            //Fade In
            if (!hasFadedStart)
            {
                //fadeScript.StartFadeScreen();
                hasFadedStart = true;
            }
            sceneTimer -= 1 * Time.deltaTime;

            if(sceneTimer <= .5f && sceneTimer > 0f) {

                //Fade out
                if (!hasFadedEnd)
                {
                    fadeScript.StartFadeScreen();
                    hasFadedEnd = true;
                }
            }
            
            if(sceneTimer <= 0)
            {
                cutscene.SetActive(false);
                playerMoveScript.EnableMovement(true);
                if(canReplay) sceneTimer = sceneTimeStart;
                if(postSceneObject != null) postSceneObject.SetActive(enablePostSceneObject);
                if(postSceneObject2 != null) postSceneObject2.SetActive(enablePostSceneObject2);
            }
            else
            {
                cutscene.SetActive(true);
                playerMoveScript.EnableMovement(false);
                if (postPlayerPosition != null)
                {
                    playerObject.transform.position = new Vector3(
                        postPlayerPosition.position.x,
                        postPlayerPosition.position.y,
                        0
                        );
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            playerObject = collision.gameObject;
            playerMoveScript = playerObject.GetComponent<CharacterMovement>(); 
        }
    }
}
