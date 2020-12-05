using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public static float globalGameSpeed = 3f;
    private float globalTime = 0f;
    void Start() {
        
    }
    void Update() {
        globalTime += Time.deltaTime;
        globalGameSpeed += 0.01f * Time.deltaTime;
        Debug.Log(globalGameSpeed);
    }
}
