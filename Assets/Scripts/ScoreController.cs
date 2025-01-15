using System;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    private float nextUpdateTime = 0f;
    private int incrementBySceneIndex;

    private void Start()
    {
        incrementBySceneIndex = GameManager.instance.sceneIndex;
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.isBallMoving)
        {
            if (Time.time >= nextUpdateTime)
                score += 1;
            nextUpdateTime = Time.time + 1f;
        }
    }
}