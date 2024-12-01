using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

public class InputHandler : MonoBehaviour
{
    //private PlayerInputs playerInput;

    public static bool movingRight = false;
    // private void Awake()
    // {
    //     playerInput = new PlayerInputs();
    //     playerInput.Movement.TapX.performed += MovePlayer;
    // }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Input alindi moveright degerinin tersi kendine atandi");
            Debug.Log(movingRight);
            movingRight = !movingRight;
        }
    }

    //
    // private void MovePlayer(InputAction.CallbackContext context)
    // {
    //     if (context.ReadValueAsButton())
    //     {
    //     }
    // }
}