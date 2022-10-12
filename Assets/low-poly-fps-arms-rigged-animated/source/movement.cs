using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Rigidbody rb;
    Vector3 rotationVector;
    bool isHeld = false;
    float speed = 0.2f;
    float thrust = 12f;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //jump
       if(Input.GetKeyDown(KeyCode.Space)){
        rb.AddForce(transform.up * thrust);
       } 
        
        //walk forwards
       if(Input.GetKey(KeyCode.UpArrow)){
        transform.Translate(Vector3.forward * speed, Camera.main.transform);
       } 

       if(Input.GetKeyUp(KeyCode.UpArrow)){
        VerticalStop();
       } 

        //walk backwards
       if(Input.GetKey(KeyCode.DownArrow)){
        transform.Translate(Vector3.forward * -speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.UpArrow)){
        VerticalStop();
       } 

       //walk Left
       if(Input.GetKey(KeyCode.LeftArrow)){
         transform.Translate(Vector3.left * speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.LeftArrow)){
         SideStop();
       } 

       //walk right
       if(Input.GetKey(KeyCode.RightArrow)){
         transform.Translate(Vector3.left * -speed, Camera.main.transform);
       } 
       
        //stop
       if(Input.GetKeyUp(KeyCode.RightArrow)){
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

       //turn camera
        if(Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 91 && Input.GetAxis("Mouse Y") > -91){
            Debug.Log("turn");
            rotationVector = new Vector3(Input.GetAxis("Mouse X"), 0);
        }
}
        void SideStop(){
           transform.Translate(Vector3.left * 0, Camera.main.transform);
        }

        void VerticalStop(){ // up down stop
            transform.Translate(Vector3.forward * 0, Camera.main.transform);
        }

        private void OnCollisionEnter(Collision other) {
        }
}