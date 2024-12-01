using System;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb; // fizik bileseni 

    private float moveX = 0.65f; // top -moveX ve moveX degerleri arasinda gidecek (Mathf.clamp() ile sinirlandirilacak)
    private Vector3 targetPosition;
    [SerializeField] private int forwardSpeed = 22; // z ekseninde topun temel hareketi
    [SerializeField] private int moveXSpeed = 20; // x ekseninde hareket etme hizi
    [SerializeField] private int jumpingForce = 50; //ziplama gucu

    private float rotationSpeed = 2;
    
    // [SerializeField] private int fallSpeed = 45;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -60f, 0);

        targetPosition = transform.position; // nesnenin baslangictaki konumunu targetpos(hedefpozisyon)`a atadik
    }


    private void FixedUpdate() // fizik olaylarlarinda update Yerine fixedUpdate kullanilmali
    {
        // top hareket ediyor ise topun rb bileseninin hizina `Z eksen hizini` atadik
        if (CollisionDetect.isBallMoving)
        {
            rb.MovePosition(rb.position + Vector3.forward * (forwardSpeed * Time.fixedDeltaTime));
            // rb.position += Vector3.forward * (Time.fixedDeltaTime * forwardSpeed);
        }

        // objemiz jumpingPad ile temas ederse ziplama methodunu calistirip jump(bool)i tekrar false yaptik
        if (CollisionDetect.jump)
        {
            CollisionDetect.jump = false;
            rb.AddForce(Vector3.up * jumpingForce, ForceMode.Impulse);
        }


        if (InputHandler.movingRight && CollisionDetect.isBallMoving)
        {
            targetPosition = new Vector3(Mathf.Clamp(transform.position.x + moveX, -moveX, moveX),
                transform.position.y, rb.position.z);
        }
        else if (!InputHandler.movingRight && CollisionDetect.isBallMoving)
        {
            targetPosition = new Vector3(Mathf.Clamp(transform.position.x - moveX, -moveX, moveX), rb.position.y,
                transform.position.z);
        }

        // Lerp(Dogrususal interpolasyon) kullanmamizin sebebi x ekseninde yumusak bi gecis elde etmek
        float smoothX = Mathf.Lerp(rb.position.x, targetPosition.x, Time.fixedDeltaTime * moveXSpeed);
        float smoothZ = Mathf.Lerp(rb.position.z, targetPosition.z, Time.fixedDeltaTime * forwardSpeed);

        Vector3 newPosition = new Vector3(smoothX, rb.position.y, rb.position.z);
        rb.MovePosition(newPosition);
    }

    private void Update()
    {
        // topa donme islemi uygulayacagiz
        if(CollisionDetect.isBallMoving && Time.timeScale != 0)
            transform.Rotate(Vector3.right * rotationSpeed);
    }
    // private void PlayerJump()
    // {
    //     rb.velocity = Vector3.up * jumpingForce;
    // }
}