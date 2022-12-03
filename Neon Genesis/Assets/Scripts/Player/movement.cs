using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour, Observer
{

    public Rigidbody rb;
    float speed;
    float jumpingForce = 10f;
    bool isGrounded = true;
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    public int targetFrameRate = 30;

    private PlayerStats m_PlayerStats;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
        m_PlayerStats = GetComponent<PlayerStats>();
        speed = m_PlayerStats.Speed;
    }

    // Update is called once per frame
    void Update()
    {

        //jump (the user should only be able to jump when grounded (isGrounded = true)) 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = transform.up * jumpingForce;
            isGrounded = false;
        }


        //walk forwards
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed, Camera.main.transform);
        }



        //sprint (zoom the FoV when user wants to sprint)
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = m_PlayerStats.Speed * 2;
            Camera.main.fieldOfView = 65;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = m_PlayerStats.Speed;
            Camera.main.fieldOfView = 75;
        }

        //walk backwards
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * -speed, Camera.main.transform);
        }

        //walk Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed, Camera.main.transform);
        }

        //walk right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.left * -speed, Camera.main.transform);
        }

        //crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.transform.localScale = new Vector3(1f, 0.2f, 1f);
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            rb.transform.localScale = new Vector3(1f, 1f, 1f);
        }

        //move camera
        var c = rb.transform;
        currentRotation.x += Input.GetAxisRaw("Mouse X") * sensitivity;
        currentRotation.y -= Input.GetAxisRaw("Mouse Y") * sensitivity;
        currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
        currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
        c.rotation = Quaternion.Euler(currentRotation.y, currentRotation.x, 0);
    }

    /*
    * makes sure that the user makes contact with the ground.
    * Once they do, the isGrounded flag is turn to true and
    * the user is then given the ability to jump again
    */
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "MAP")
        {
            isGrounded = true;
        }
    }

    public void SubjectUpdate()
    {
        speed = m_PlayerStats.Speed;
    }
}