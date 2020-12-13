using System.Collections;
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

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AUsrc.Play(0);
            Shoot();
        }
    }



    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // bang.Play();
        // AUsrc.playOneShot(bang);

        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
    }
}
