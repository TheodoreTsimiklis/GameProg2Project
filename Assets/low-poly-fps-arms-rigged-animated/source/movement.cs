using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    Vector3 rotationVector;
    bool isHeld = false;
    float speed = 0.02f;
    float thrust = 8f;
    bool isGrounded = true;
    public float sensitivity = 10f;


    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {

        //jump
       if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        rb.velocity = transform.up * thrust;
        isGrounded = false;
         
       } 
        
        //walk forwards
       if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        transform.Translate(Vector3.forward * speed, Camera.main.transform);
       } 

       if(Input.GetKeyDown(KeyCode.Space)){
        rb.AddForce(transform.up * thrust);
       } 
        
        //sprint
       if(Input.GetKey(KeyCode.LeftShift)){
        speed = 0.05f;
        Camera.main.fieldOfView = 45;
       } 

       if(Input.GetKeyUp(KeyCode.LeftShift)){
        speed = 0.02f;
        Camera.main.fieldOfView = 60;
       } 

        //walk backwards
       if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
        transform.Translate(Vector3.forward * -speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
        VerticalStop();
       } 

       //walk Left
       if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
         transform.Translate(Vector3.left * speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
         SideStop();
       } 

       //walk right
       if(Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.D)){
         transform.Translate(Vector3.left * -speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
         SideStop();
       } 


        //hold mouse button
       if(Input.GetMouseButtonDown(0)){
            isHeld = true;
       }

        //if user lets go of left click the "hold" flag is set to off
       if(Input.GetMouseButtonUp(0)){
            isHeld = false;
       }

       //uncrouch
       if(Input.GetKey(KeyCode.LeftControl)){
         rb.transform.localScale = new Vector3(1f, 0.2f, 1f);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.LeftControl)){
         rb.transform.localScale = new Vector3(1f, 1f, 1f);
       } 



       if(Input.GetKey(KeyCode.Escape)){
          SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }

/*
       //turn camera
        if(Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 91 && Input.GetAxis("Mouse Y") > -91){
            Debug.Log("turn");
            rotationVector = new Vector3(Input.GetAxis("Mouse X"), 0);
        }
*/

         var c = rb.transform;
         c.Rotate(0, Input.GetAxis("Mouse X")* sensitivity, 0);

         if(-Input.GetAxis("Mouse Y") > -91 && -Input.GetAxis("Mouse Y") < 91)
          c.Rotate(-Input.GetAxis("Mouse Y")* sensitivity, 0, 0);
         c.Rotate(0, 0, -Input.GetAxis("QandE")*90 * Time.deltaTime);
         if (Input.GetMouseButtonDown(0)){
             Cursor.lockState = CursorLockMode.Locked;
          }

      

}
        void SideStop(){
           transform.Translate(Vector3.left * 0, Camera.main.transform);
        }

        void VerticalStop(){ // up down stop
            transform.Translate(Vector3.forward * 0, Camera.main.transform);
        }

        private void OnCollisionEnter(Collision other) {
          if(other.gameObject.name == "floor"){
            isGrounded = true;
          }
        }
}