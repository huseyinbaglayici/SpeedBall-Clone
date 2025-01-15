using System;
using UnityEditor;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // rigidbody componenti ve hedefin pozisyonu
    private Rigidbody rb;
    private Vector3 targetPosition;

    [Header("Switch boundary between two x axis")] [SerializeField]
    private float moveX = 0.3f; // top -moveX ve moveX degerleri arasinda gidecek (Mathf.clamp() ile sinirlandirilacak)

    [Header("Parameters for ball movement")] [SerializeField]
    private int forwardSpeed = 22; // z ekseninde topun temel hareketi

    [SerializeField] [Range(1, 30)] private float moveXSpeed = 5f; // x ekseninde hareket etme hizi
    [SerializeField] private float jumpingForce; //ziplama g
    [SerializeField] [Range(-20, 20)] private float gravity;
    private Vector3 gravityVector;

    [Header("Rotation for ball material")] [SerializeField]
    private float rotationSpeed = 2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("rb doesnt found");
        }
    }

    private void Start()
    {
        switch (GameManager.instance.sceneIndex)
        {
            case 0:
                forwardSpeed = 15;
                break;
            case 1:
                forwardSpeed = 20;
                break;
            case 2:
                forwardSpeed = 25;
                break;
            case 3:
                forwardSpeed = 30;
                break;
            case 4:
                forwardSpeed = 35;
                break;
            case 5:
                forwardSpeed = 40;
                break;
            case 6:
                forwardSpeed = 45;
                break;
            case 7:
                forwardSpeed = 50;
                break;
            case 8:
                forwardSpeed = 65;
                break;
        }

        gravityVector = new Vector3(0, gravity, 0);
        rb = GetComponent<Rigidbody>();
        Physics.gravity = gravityVector;

        targetPosition = transform.position; // nesnenin baslangictaki konumunu targetpos(hedefpozisyon)`a atadik
    }


    private void FixedUpdate() // fizik olaylarlarinda update Yerine fixedUpdate kullanilmali
    {
        // top hareket ediyor ise topun rb bileseninin hizina `Z eksen hizini` atadik
        if (GameManager.instance.isBallMoving)
        {
            rb.MovePosition(rb.position + Vector3.forward * (forwardSpeed * Time.fixedDeltaTime));
        }

        // objemiz jumpingPad ile temas ederse ziplama methodunu calistirip jump(bool)i tekrar false yaptik
        if (GameManager.instance.jump)
        {
            PlayerJump();
        }

        Debug.Log(forwardSpeed);

        if (InputHandler.movingRight &&
            GameManager.instance.isBallMoving)
        {
            targetPosition = new Vector3(Mathf.Clamp(transform.position.x + moveX, -moveX, moveX),
                transform.position.y, rb.position.z);
        }
        else if (!InputHandler.movingRight && GameManager.instance.isBallMoving)
        {
            targetPosition = new Vector3(Mathf.Clamp(transform.position.x - moveX, -moveX, moveX), rb.position.y,
                transform.position.z);
        }

        // Lerp(Dogrususal interpolasyon) kullanmamizin sebebi x ekseninde yumusak bi gecis elde etmek
        float smoothX = Mathf.Lerp(rb.position.x, targetPosition.x, Time.fixedDeltaTime * moveXSpeed);
        Vector3 newPosition = new Vector3(smoothX, rb.position.y, rb.position.z);
        rb.MovePosition(newPosition);
    }

    private void Update()
    {
        // topa donme islemi uygulayacagiz
        if (GameManager.instance.isBallMoving && Time.timeScale != 0)
            transform.Rotate(Vector3.right * rotationSpeed);
    }

    private void PlayerJump()
    {
        GameManager.instance.jump = false;
        rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
    }
}