using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarController : MonoBehaviour
{
   private Slider healthSlider;
    private void Start() {
        healthSlider = GetComponentInChildren<Slider>();
        EventManager.current.onTakeDamage += TakeDamage;
    }
    private void OnEnable() {
        
    }
    void OnDisable() {
        EventManager.current.onTakeDamage -= TakeDamage;
    }
    void TakeDamage() {
        Debug.Log("heh", healthSlider);
        healthSlider.value -= 1;

        if (healthSlider.value <= 0) {
           SceneManager.LoadScene("GameOver");
        }
    }
}
