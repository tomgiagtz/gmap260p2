using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
   private Slider healthSlider;
    private void Start() {
        healthSlider = GetComponentInChildren<Slider>();
    }
    private void OnEnable() {
        EventManager.current.onTakeDamage += TakeDamage;
    }
    void OnDisable() {
        EventManager.current.onTakeDamage -= TakeDamage;
    }
    void TakeDamage() {
        Debug.Log("heh");
        healthSlider.value -= 1;
    }
}
