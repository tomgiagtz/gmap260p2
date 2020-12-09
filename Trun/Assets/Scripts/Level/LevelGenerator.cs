using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    public Transform[] spawnPoints;
    public GameObject[] rowTypes;
    public float platformInterval = 5f;
    private float deltaTime = 0f;

    private void Update() {
        deltaTime += Time.deltaTime;
        if (deltaTime >= platformInterval * LevelController.globalGameSpeed * 0.9f) {
            int randomIndex = Random.Range(0, rowTypes.Length);
            Instantiate(rowTypes[randomIndex], transform.position, Quaternion.identity);
            deltaTime = 0f;
        }
    }
}
