using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobaleVariable : MonoBehaviour
{
     public static int num = 1;

        public int Num   // property
        {
            get { return num; }   // get method
            set { num = value; }  // set method
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
