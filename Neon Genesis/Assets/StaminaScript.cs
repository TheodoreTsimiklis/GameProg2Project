using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    /**
    *This method is to set the max value of the stamina
    */
    public void SetMaxStamina(int stamina) {
        slider.value = stamina;
        slider.maxValue = stamina;
        fill.color = gradient.Evaluate(1f);
    }

    /**
    *This method is to set the stamina 
    */
    public void SetStamina(int stamina) {
        slider.value = stamina;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
