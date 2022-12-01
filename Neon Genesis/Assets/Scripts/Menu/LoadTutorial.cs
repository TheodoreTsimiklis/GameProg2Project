using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTutorial : MonoBehaviour
{
    
    public void switchTutorial() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

}
