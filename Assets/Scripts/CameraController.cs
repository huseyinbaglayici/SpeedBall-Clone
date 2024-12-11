using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target; //top 

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        //2.118f
        transform.position = new Vector3(0,transform.position.y, targetPosition.z);
    }
}