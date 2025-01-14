using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public static MenuController instance;

    [SerializeField] internal GameObject mainPanel;
    [SerializeField] internal GameObject gameOverPanel;
    [SerializeField] internal GameObject levelCompletedPanel;
    [SerializeField] internal GameObject LevelInfo;

    [SerializeField] internal GameObject LevelSelectPanel;
    [SerializeField] internal GameObject LevelSelectMenu;

    [SerializeField] internal GameObject TapToPlaybtn;

    [SerializeField] private GameManager _gameManager;
    
        //blinking tap to play
        public TextMeshProUGUI target;
        public float speed = 1f;

        private float _t = 0f;
        

    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(this);
        instance = this;
    }

    private void Update()
    {
        _t += Time.deltaTime * speed;
        target.alpha = Mathf.PingPong(_t, 1f);
    }

    public void LevelPanelShow()
    {
        CinemachineController.instance.SwitchToLevelCam();
        LevelSelectMenu.SetActive(true);
        TapToPlaybtn.SetActive(false);
    }

    public void LevelPanelExit()
    {
        LevelSelectMenu.SetActive(false);
        CinemachineController.instance.SwitchToPlayerCam();
        TapToPlaybtn.SetActive(true);
    }
}