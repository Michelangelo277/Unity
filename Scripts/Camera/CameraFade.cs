using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFade : MonoBehaviour
{
    public float speedScale = 1f;
    public Color fadeColor = Color.black;

    public AnimationCurve curve = new AnimationCurve(
        new Keyframe(0, 1),
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f),
        new Keyframe(1, 0)
        );

    public bool startFadedOut = false;

    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    public float time = 0f;
    private bool canFade;

    // Start is called before the first frame update
    void Start()
    {
        if (startFadedOut)
            alpha = 1f;
        else
            alpha = 0f;

        //Apply colored 1x1 sprite
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();

        canFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 0 && canFade)
        {
            if (alpha >= 1f) //Fully faded out
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
            }
            else // Fully faded in
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }

            canFade = false;
        }
    }

    public void OnGUI()
    {
        if (alpha > 0f)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        }

        if (direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();

            if (time <= 0f || time >= 1f)
            {
                direction = 0;
            }
        }

    }

    public void StartFadeScreen() 
    {
        canFade = true;
    }
}
