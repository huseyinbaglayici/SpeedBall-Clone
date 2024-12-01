using System;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public static bool isBallMoving = false;
    public static bool jump = false;
    public static bool isGrounded = false;

    public GameObject levelCompletedPanel;


    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            Debug.Log("carpti");
            GameManager._gameOver = true;
        }
        else if (other.collider.tag == "Finish")
        {
            GameManager._levelCompleted = true;
            Debug.Log("Game has been finished succesfully");
        }
        else if (other.collider.tag == "JumpingPad")
        {
            jump = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
        else
            isGrounded = false;
    }

}