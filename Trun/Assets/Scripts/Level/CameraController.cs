using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float deltaY = 5f;
    public float slideUpSpeed = 1f;
    private float endPosition;
    private void Start() {
        endPosition = transform.position.y + deltaY;
    }
    void Update() {
       if (transform.position.y < endPosition){
           transform.Translate(Vector3.up * slideUpSpeed * Time.deltaTime);
       }
   }
}
