using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class CollisionDetect : MonoBehaviour
{
    

    private void Update()
    {
        if (GameManager.instance._gameOver)
        {
            GameManager.instance.GameOver();
        }
        else if (GameManager.instance._levelCompleted)
        {
            GameManager.instance.LevelCompleted();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Obstacle")
        {
            GameManager.instance._gameOver = true;
            GameManager.instance.isBallMoving = false;
        }
        else if (other.collider.tag == "Finish")
        {
            GameManager.instance._levelCompleted = true;
                GameManager.instance.isBallMoving = false;
        }
        else if (other.collider.tag == "JumpingPad")
        {
            GameManager.instance.jump = true;
        }
    }

}