using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private Vector3 mousePos;

    // Update is called once per frame
    void Start()
    {
        canFire = true;
    }
    void Update()
    {
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetButtonDown("Fire1") && canFire)
        {
            canFire = false;
            Shoot();    
        }
    }
        void Shoot()
        {
        
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        }
    
}