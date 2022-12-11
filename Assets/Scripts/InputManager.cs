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
    private float jumpAmount = 10;
    private float maxSpeed = 5;

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
        //TODO Fix jumping, currently doesn't move properly with right or left, and does not jump high enough.
        Vector2 inputVector = Vector2.zero;
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        if (Input.GetKey("w") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            
        }
        if (Input.GetKey("d") && isTouchingGround)
        {
            inputVector += Vector2.right;
            renderer.flipX = false;
        }
        else if (Input.GetKey("a") && isTouchingGround)
        {
            inputVector += Vector2.left;
            renderer.flipX = true;
        }
        if (inputVector != Vector2.zero)
        {
           //inputVector.Normalize();
            rb.velocity = inputVector * maxSpeed;
        }
        
        
    }


    void FixedUpdate()
    {


    
    }
}
