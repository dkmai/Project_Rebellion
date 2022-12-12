using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform transform;
    [SerializeField] public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private float jumpAmount = 15;
    private float maxSpeed = 6;
    private bool m_FacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {  
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * maxSpeed, rb.velocity.y);
        if(dirX < 0 && m_FacingRight)
        {
            Flip();
        }

        if(dirX > 0 && !m_FacingRight)
        {
            Flip();
        }

        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
        }

        if (Input.GetKey("s"))
        {
            
        }
        
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180, 0);
    }

}
