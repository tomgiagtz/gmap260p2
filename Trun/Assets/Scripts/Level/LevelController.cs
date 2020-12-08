using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public static float globalGameSpeed = 1f;
    [Range (0f, 0.1f)]
    public float deltaSpeed = 0.01f;
    public static float globalTime = 0f;
    void Update() {
        globalTime += Time.deltaTime;
        globalGameSpeed += deltaSpeed * Time.deltaTime;
    }
}
