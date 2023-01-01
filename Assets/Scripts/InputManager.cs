using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform transform;
    [SerializeField] public Transform groundCheck;
    public BoxCollider2D collider;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Vector2 cOffset;
    private Vector2 cSize;
    private bool isCrouching;
    public bool inFreezeTime; //Will be used to check if the player is currently in a teleport freeze state.
    private float jumpAmount = 15;
    private float maxSpeed = 6;
    private bool m_FacingRight = true;
    private float baseHeight;
    // Start is called before the first frame update
    void Start()
    {
        cOffset = collider.offset;
        cSize = collider.size;
        isCrouching = false;
        baseHeight = collider.size.y;
        inFreezeTime = false;
    }

    // Update is called once per frame
    void Update()
    {  
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (inFreezeTime != true)
        {
            float dirX = Input.GetAxisRaw("Horizontal");
            if (!isCrouching)
            {
                rb.velocity = new Vector2(dirX * maxSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(dirX * maxSpeed * .5f, rb.velocity.y);
            }
            if(dirX < 0 && m_FacingRight)
            {
                Flip();
            }

            if(dirX > 0 && !m_FacingRight)
            {
                
                Flip();
            }

            if (Input.GetButtonDown("Jump") && isTouchingGround && !isCrouching)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            }
            
            if (Input.GetKey("s") && isTouchingGround && !isCrouching)
            {
                isCrouching = true;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                collider.size = new Vector2(collider.size.x, 0.7217519f);
                collider.offset = new Vector2 (cOffset.x, -0.440516f);
            }
            if (!Input.GetKey("s"))
            {
                isCrouching = false;
                rb.constraints = RigidbodyConstraints2D.None;
                collider.size = cSize;
                collider.offset = cOffset;
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
            if (isCrouching)
            {
                isCrouching = false;
                rb.constraints = RigidbodyConstraints2D.None;
                collider.size = cSize;
                collider.offset = cOffset;
            }
            
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
