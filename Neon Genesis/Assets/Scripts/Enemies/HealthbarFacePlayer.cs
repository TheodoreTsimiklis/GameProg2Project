using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarFacePlayer : MonoBehaviour
{
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
