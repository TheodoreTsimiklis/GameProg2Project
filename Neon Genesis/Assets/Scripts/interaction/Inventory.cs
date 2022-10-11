using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool hasItem1 = false;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) hasItem1 = !hasItem1;    
    }
}
