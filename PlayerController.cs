using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float sprintSpeed;
    public float jumpPower;
    public Rigidbody2D rb;
    public LayerMask groundLayerMask;
    public bool isMovementEnabled;
    
    private Animator animator;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(h * movementSpeed, rb.velocity.y);

        // sprint if holding left shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = new Vector2(h * sprintSpeed, rb.velocity.y);
            animator.SetFloat("speedMultiplier", 1.5f);
        } else
        {
            animator.SetFloat("speedMultiplier", 1);
        }

        // set run animation if player is moving horizontal
        animator.SetFloat("moveHorizontal", h);
        
        // set idle animation if player is not running
        if (h > 0.1 || h < -0.1)
        {
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }

        // set jump animation
        animator.SetFloat("velocityY", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded());
    }

    private void FixedUpdate()
    {
        // jump
        if (isGrounded() && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().JumpSound();
        }
    }

    private bool isGrounded()
    {
        float extraHeightTest = 0.1f;

        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraHeightTest, groundLayerMask);

        /* 
        Color rayColor;
        if (hit.collider != null)
        {
            rayColor = Color.green;
        } else
        {
            rayColor = Color.red;
        } 

        Debug.Log(hit.collider);
        Debug.DrawRay(boxCollider2D.bounds.center + new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, 0), Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightTest), rayColor);
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(boxCollider2D.bounds.extents.x, boxCollider2D.bounds.extents.y + extraHeightTest), Vector2.right * (boxCollider2D.bounds.extents.x), rayColor);
        */

        return hit.collider != null;
    }
}
