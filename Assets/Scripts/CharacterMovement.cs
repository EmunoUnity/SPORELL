using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private float speed = 7.0f;

    public Camera camera1;
    private Vector3 moveDirection = Vector3.zero;
    public Transform camTran;

    public bool isRunning;
    public bool stopMovement;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        isRunning = false;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMovement)
        {
            float hInport = Input.GetAxis("Horizontal");
            float vInport = Input.GetAxis("Vertical");

            transform.Translate(Vector3.right * Time.deltaTime * speed * hInport);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * vInport);

            moveDirection = new Vector3(hInport, 0, vInport);
            moveDirection = camTran.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {

                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }

                if (moveDirection.sqrMagnitude > 0 && !isRunning)
            {
                Debug.Log("Is walking");

            }

            if (moveDirection.sqrMagnitude == 0 || isRunning)
            {
                Debug.Log("Stopped walking");

            }

            if (isRunning == true)
            {
                speed = 15.0f;
                if (moveDirection.sqrMagnitude > 0)
                {
                    //running.Play();
                }
                if (moveDirection.sqrMagnitude == 0)
                {
                    //running.Pause();
                }

            }
        }

        if (isRunning == false)
        {
            speed = 5.0f;
        }

        transform.rotation = Quaternion.Euler(0, camera1.transform.eulerAngles.y, 0);

        //Made player do something with camera
        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, camera1.transform.localEulerAngles.y, transform.localEulerAngles.z);
        /*if (staminabar.instance.cur >= 5)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                isRunning = true;
                instance = GetComponent<staminabar>();
                staminabar.instance.useeStamina(100/5 * Time.deltaTime);
            }
            else
            {
                isRunning = false;
            }
        }
        else
        {
            isRunning = false;
        }*/


    }
}
