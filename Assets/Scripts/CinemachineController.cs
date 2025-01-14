using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class CinemachineController : MonoBehaviour
{
    internal static CinemachineController instance;

    [SerializeField] internal CinemachineVirtualCamera virtualCam1;
    [SerializeField] internal CinemachineVirtualCamera virtualCam2;
    [SerializeField] internal CinemachineVirtualCamera virtualCam3;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    internal void SwitchToLevelCam()
    {
        virtualCam1.Priority = 10;
        virtualCam2.Priority = 11;
    }

    internal void SwitchToPlayerCam()
    {
        virtualCam1.Priority = 11;
        virtualCam2.Priority = 10;
        virtualCam3.Priority = 10;
    }

    internal void SwitchToGameOverCam()
    {
        virtualCam1.Priority = 10;
        virtualCam2.Priority = 10;
        virtualCam3.Priority = 11;
    }
}