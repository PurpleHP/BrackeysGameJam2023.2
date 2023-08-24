using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shooting : MonoBehaviour
{
    public Transform firePoint; //normalde Transform sadece, alttaki transformlar yok
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private bool canShoot = true;
    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.5f);
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            Shoot();
            StartCoroutine(Cooldown());
            
        }
        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 3f);
            
        }
    }
}
