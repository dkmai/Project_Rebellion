using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private float jumpAmount = 13;
    private float maxSpeed = 6;

    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        if (renderer == null)
        {
            Debug.LogError("Player sprite is missing a renderer");
        }
    }

    // Update is called once per frame
    void Update()
    {  
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * maxSpeed, rb.velocity.y);
        if(dirX < 0)
        {
            renderer.flipX = true;
        }

        if(dirX > 0)
        {
            renderer.flipX = false;
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }
    }
}
