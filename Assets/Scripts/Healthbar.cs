using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int currentHealth) {
        slider.maxValue = currentHealth;
        slider.value = currentHealth; 

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int currentHealth) {
        slider.value = currentHealth;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
