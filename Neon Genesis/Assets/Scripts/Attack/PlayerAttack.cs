using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    int movementSpeed = 5;
    Animator[] sword;
    // Start is called before the first frame update
    void Start()
    {
        sword = GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed,0,0));
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed,0,0));
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,movementSpeed));
        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-movementSpeed));    

        if (Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("SPACE PRESSED");
            sword[0].enabled = true;
            sword[0].Play("swing");
        }
            
    }
}
