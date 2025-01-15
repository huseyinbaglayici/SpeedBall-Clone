using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public string activeSceneName;

    private void Awake()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
    }

    public void OpenLevel01()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
        SceneManager.LoadScene("Level01");
    }

    public void OpenLevel02()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
        SceneManager.LoadScene("Level02");
    }

    public void OpenLevel03()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
        SceneManager.LoadScene("Level03");
    }

    public void OpenLevel04()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
        SceneManager.LoadScene("Level04");
    }

    public void OpenLevel05()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
        SceneManager.LoadScene("Level05");
    }

    public void OpenLevel06()
    {
        //if (activeSceneName != SceneManager.GetActiveScene().name)
            SceneManager.LoadScene("Level06");
    }
}