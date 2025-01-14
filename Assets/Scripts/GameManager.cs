using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    internal bool _gameOver;
    internal bool _levelCompleted;
    internal bool isBallMoving = false;
    internal bool jump = false;

    internal int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
            
        instance = this;
        
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }

    internal void RetryGame()
    {
        InputHandler.cameraLocked = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CinemachineController.instance.SwitchToPlayerCam();
        MenuController.instance.gameOverPanel.SetActive(false);
        MenuController.instance.mainPanel.SetActive(true);
        MenuController.instance.LevelSelectPanel.SetActive(true);
    }

    internal void StartGame()
    {
        _levelCompleted = false;
        MenuController.instance.mainPanel.SetActive(false);
        MenuController.instance.LevelSelectPanel.SetActive(false);
        Time.timeScale = 1;
        isBallMoving = true;
    }

    internal void GameOver()
    {
        _gameOver = false;
        isBallMoving = false;
        CinemachineController.instance.SwitchToGameOverCam();
        MenuController.instance.gameOverPanel.SetActive(true);
    }

    internal void LevelCompleted()
    {
        MenuController.instance.levelCompletedPanel.SetActive(true);
        StartCoroutine(LevelCompletionWait());
    }


    IEnumerator LevelCompletionWait()
    {
        yield return new WaitForSeconds(3f);
        if(SceneManager.GetActiveScene().buildIndex + 1==5)
            Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}