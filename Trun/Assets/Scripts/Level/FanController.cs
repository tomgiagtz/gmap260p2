using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    // private float rotation = 0f;
    public bool clockwise = true;
    public float rotationSpeed = 30f;
    private SpriteRenderer sprite;
    private void Start() {
        if (clockwise) {
            transform.localScale = new Vector3(-1.0f, 1f, 1f);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * (clockwise ? 1 : -1));
    }
}
