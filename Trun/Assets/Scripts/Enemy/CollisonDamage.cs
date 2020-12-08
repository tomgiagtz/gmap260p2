using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisonDamage : MonoBehaviour
{
    public int health = 1;
    public AudioClip OnDestroySound;
    public GameObject Explosion;

    public float invulnPlayer = 0;
    float invulnTimer = 0;
    int correctLayer;

    void Start()
    {
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("TRIGGERED!");

        health--;
        if (health <= 0)
        {
            Destruct();
        }
    }

    void Update()
    {

    }

    void Destruct()
    {
        AudioSource.PlayClipAtPoint(OnDestroySound, this.transform.position);
        GameObject explosion = (GameObject)Instantiate(Explosion);
        explosion.transform.position = transform.position;
        Destroy(gameObject);
    }

}
