using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Range(0, 2)]
    public float speed = 1f;
    public bool positive = false;
    public float timeMovement = 3f;
    private float timeDelta = 0f;
    void Update()
    {   
        if (timeDelta >= timeMovement) {
            positive = !positive;
            timeDelta = 0f;
        }
        Vector3 movement;
        if (positive) {
            movement = Vector3.up* Time.deltaTime * speed * 2;
        } else {
            movement = Vector3.down * Time.deltaTime * speed * 2;
        }
        transform.Translate(movement);
        timeDelta += Time.deltaTime;
        CheckOffScreen();
    }



    private void CheckOffScreen()  {
        if (transform.position.y <= -1f) {
            Destroy(gameObject);
        }
    }
}
