using System;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static bool movingRight;
    public static bool cameraLocked = true;
    public Touch touch;

    private void Start()
    {
        movingRight = false;
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     movingRight = !movingRight;
        //     cameraLocked = false;
        // }
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                movingRight = !movingRight;
                cameraLocked = false;
            }
        }
    }
}