﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{

    public static AudioClip bang;
    
    public AudioSource AUsrc;


    // public AudioSource bang;
    public GameObject bulletPrefab;

    public Transform firepoint;

    public float bulletForce = 15.0f;
    

    // Start is called before the first frame update
    void Start()
    {

        // bang = Sound.Load<AudioClip>("shoot1");

        AUsrc = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }



    void Shoot()
    {
        
        
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // bang.Play();
        AUsrc.Play(0);

        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }
}
