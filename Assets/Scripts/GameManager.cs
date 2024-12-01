using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;

    // private bool isGameOverMenuVisible = false;
    // private bool isMainMenuVisible = true;
    // private bool tapToState = true;

    public static bool _gameOver;
    public static bool _levelCompleted;

    private void Update()
    {
        if (_gameOver)
        {
            GameOver();
        }
        else if (_levelCompleted)
        {
            LevelCompleted();
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

    public void StartGame()
    {
        _levelCompleted = false;
        mainPanel.SetActive(false);
        Time.timeScale = 1;
        CollisionDetect.isBallMoving = true;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOver = false;
        gameOverPanel.SetActive(true);
        //isGameOverMenuVisible = true;
    }

    private void LevelCompleted()
    {
        Time.timeScale = 0;
        levelCompletedPanel.SetActive(true);
    }

    // public void NextLevel()
    // {
    // }
}