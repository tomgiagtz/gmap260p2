using System;using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    private void Awake() {
        current = this;
    }
    public event Action onTakeDamage;
    public void HandleTakeDamage() {
        if (onTakeDamage != null) {
            onTakeDamage();
        }
    }
}
