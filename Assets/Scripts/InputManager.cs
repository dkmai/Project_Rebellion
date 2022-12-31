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
    public bool inFreezeTime; //Will be used to check if the player is currently in a teleport freeze state.
    private float jumpAmount = 15;
    private float maxSpeed = 6;
    private bool m_FacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        inFreezeTime = false;
    }

    // Update is called once per frame
    void Update()
    {  
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (inFreezeTime != true)
        {
            
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


            //TODO - implement crouching
            if (Input.GetKey("s"))
            {
                
            }
        }

        
        CheckFreezeTime();


        
        
    }

    // CheckFreezeTime() - allows the player to freeze time (TODO should only be in freeze time for a certain duration i.e. 5 or 6 seconds)
    private void CheckFreezeTime()
    {
        if (Input.GetKeyDown("q"))
        {
            inFreezeTime = !inFreezeTime;
        }

        if (inFreezeTime)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
        if (!inFreezeTime)
        {
            Debug.Log("We are no longer in freeze time!");
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }
    //Flip() - mirrors player character based off where they're already facing
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180, 0);
    }

    //OnCollisionEnter2D() - our die function. 
    void OnCollisionEnter2D (Collision2D c)
    {
        if (c.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
