using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health = 1;

    public float invulnPlayer = 0;
    float invulnTimer = 0;
    int correctLayer;
    // Use this for initialization
    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Enemy")
        {
            health -= 20;
            invulnTimer = invulnPlayer;
            gameObject.layer = 10;
        }
    }
    // Update is called once per frame
    void Update()
    {
        invulnTimer -= Time.deltaTime;
        if (invulnTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }

        if (health <= 0)
        {
            destruct();
        }

    }

    void destruct()
    {
        Destroy(gameObject);
    }
}
