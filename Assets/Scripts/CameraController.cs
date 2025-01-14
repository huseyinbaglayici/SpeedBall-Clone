using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;

    [Header("Ball Transform & Moving X value")] [SerializeField]
    private Transform target; //top 

    [SerializeField] [Range(0, 4)] private float valueOfX;
    [SerializeField] private float clampX = 0.16f;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;


    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate() // LateUpdate yerine fixed kullanildi cunku top hareketleri fupdate ile kontrol ediliyor
    {
        Vector3 targetPosition = target.position + offset;
        if (!InputHandler.cameraLocked && !InputHandler.movingRight)
        {
            transform.position = new (Mathf.Clamp(transform.position.x - valueOfX, -clampX, clampX),
                transform.position.y, targetPosition.z);
        }
        else if (!InputHandler.cameraLocked && InputHandler.movingRight)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + valueOfX, -clampX, clampX),
                transform.position.y, targetPosition.z);
        }
        else
            transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
    }
}