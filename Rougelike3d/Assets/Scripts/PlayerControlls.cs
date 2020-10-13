using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControlls : MonoBehaviour
{
    // private float horizontalInput;
    //private float verticalInput;
    // private float jumpInput;
    //public Transform transformPlayer;
    // public float acceleration;

    public float speed = 10.0f;
    public float turningSpeed = 1f;
    public float jumpForce = 100f;
    public bool surface = true;
    float gravityModifier = 1.8f;
    //bool click = true;
    float degree = 10f;

    Vector3 verticalInput, horizontalInput;
    Vector3 jump;
    Rigidbody playerRigbody;
    Camera mainCamera;


    void Start()
    {

        Physics.gravity *= gravityModifier;
        playerRigbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void Update()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
        //  transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        //  transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);

        horizontalInput = transform.right * Input.GetAxisRaw("Horizontal");
        verticalInput = transform.forward * Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && surface)
        {
            Jump();
        }
        
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (Input.GetMouseButton(0))
        {
           
            if (groundPlane.Raycast(cameraRay, out rayLength))
            {
                Vector3 pointToLook = cameraRay.GetPoint(rayLength);
                Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

                transform.LookAt(pointToLook);

            }
        }


    }

    void FixedUpdate()
    {

        if (surface)
        {
            Movement();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Surface"))
        {
            surface = true;
        }
    }
    void Movement()
    {
        Vector3 movement = (horizontalInput + verticalInput).normalized * speed;
        playerRigbody.AddForce(movement, ForceMode.Acceleration);
    }
    void Jump()
    {
        playerRigbody.AddForce(jump * jumpForce, ForceMode.Impulse);
        surface = false;
    }
}
/*  
        if (Input.GetMouseButton(0))
        {

            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * degrees);
            //            transform.RotateAround (target.position, Vector3.left, Input.GetAxis ("Mouse Y")* dragSpeed);
        }
        if (!Input.GetMouseButton(0))
            transform.RotateAround(target.position, Vector3.up, degrees * Time.deltaTime);
        else
        {

            degrees = 0;
        }
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */