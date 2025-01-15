using System;
using System.Net.Mime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;
    private int incrementBySceneIndex;

    private void Start()
    {
        incrementBySceneIndex = GameManager.instance.sceneIndex;
    }

    private void Update()
    {
        if (GameManager.instance.isBallMoving)
        {
            score += 1;
            scoreText.text = score.ToString();
        }
    }
}