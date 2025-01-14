using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ParticleSystemController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    [SerializeField] private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule psMain;
    [SerializeField] private Color psColor;

    private void Start()
    {
        if (_particleSystem == null)
        {
            _particleSystem = GetComponent<ParticleSystem>();
        }
            
        if (_particleSystem != null)
        {
            psMain = _particleSystem.main;
            psMain.startColor = new Color(psColor.r, psColor.g, psColor.b, 1f);
        }
    }

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        var psEmission = _particleSystem.emission;
        Vector3 targetPosition = offset + target.position;
        transform.position = new Vector3(0f, 0f, targetPosition.z);
        transform.rotation = quaternion.identity;

        if (GameManager.instance.isBallMoving)
        {
            psEmission.rateOverTime = 15f;
            psMain.startSpeed = 15f;
        }
        else
        {
            psEmission.rateOverTime = 2f;
            psMain.startSpeed = 0.45f;
        }
    }
}