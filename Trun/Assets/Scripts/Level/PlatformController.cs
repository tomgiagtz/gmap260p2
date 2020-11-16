using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Range(0, 2)]
    public float speed = 1f;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed * 2);
        CheckOffScreen();
    }



    private void CheckOffScreen()  {
        if (transform.position.y <= -1f) {
            Destroy(gameObject);
        }
    }
}
