using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 1f;
    public bool positive = false;
    public float deltaY = 0f;
    private Transform topPosition;
    private Transform bottomPosition;
    void Start() {
        topPosition =  new GameObject().transform;
        bottomPosition =  new GameObject().transform;
            
        topPosition.Translate(transform.position.x, transform.position.y + deltaY,transform.position.z);
        bottomPosition.Translate(transform.position.x, transform.position.y - deltaY,transform.position.z);
    }
    void Update()
    {   
        LocalMovement();
        GlobalMovement();
        CheckOffScreen();
    }

    private void LocalMovement() {
        // if above top or below bottom, siwthc direction
        if (transform.position.y >= topPosition.transform.position.y) {
            positive = false;
        } else if (transform.position.y <= bottomPosition.transform.position.y) {
            positive = true;
        }
        
        
        //move toward top or bottom in local space
        float step = Time.deltaTime * speed;
        if (positive) {
            transform.position = Vector3.MoveTowards(transform.position, topPosition.position, step);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, bottomPosition.position, step);
        }
    }

    private void GlobalMovement() {
        topPosition.position = new Vector3(topPosition.position.x, topPosition.position.y - LevelController.globalGameSpeed * Time.deltaTime, topPosition.position.z);
        bottomPosition.position = new Vector3(bottomPosition.position.x, bottomPosition.position.y - LevelController.globalGameSpeed * Time.deltaTime, bottomPosition.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y - LevelController.globalGameSpeed * Time.deltaTime, transform.position.z);
    }
    private void CheckOffScreen()  {
        if (transform.position.y <= -1f) {
            Destroy(gameObject);
        }
    } 
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(topPosition.position, bottomPosition.position);
    }
}
