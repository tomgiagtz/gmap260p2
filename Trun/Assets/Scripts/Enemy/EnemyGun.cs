using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    private Animator animator;
    public GameObject bulletPre;

    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        var bulletfly = true;

        if (cooldownTimer <= 0)
        {
            bulletfly = false;
            cooldownTimer = fireDelay;
            Instantiate(bulletPre, transform.position, transform.rotation);
        }


        animator.SetBool("Bulletfly", bulletfly);
    }
}
