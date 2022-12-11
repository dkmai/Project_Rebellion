using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Transform currentPosition;
    public Rigidbody2D rb;
    void Start()
    {
        Vector3 shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        rb.velocity = new Vector2(shootDirection.x * speed, shootDirection.y * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
