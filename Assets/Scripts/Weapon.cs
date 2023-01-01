using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject player;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    private Vector3 mousePos;

    // Update is called once per frame
    void Start()
    {
        canFire = true;
        timeBetweenFiring = .5f;
    }
    void Update()
    {
        
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (!player.GetComponent<InputManager>().inFreezeTime)
        {
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
    }
        void Shoot()
        {
        
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        
        }
    
}