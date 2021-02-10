using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobMovement : MonoBehaviour
{
    public float mobSpeed;
    public BoxCollider2D rightLimit;
    public BoxCollider2D leftLimit;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D enemyCollider;
    private bool movingLeft;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // initial movement
        rb.velocity = new Vector2(movementDirection(mobSpeed), rb.velocity.y);
    }

    // flip enemy sprite and movement direction
    private float movementDirection(float mobSpeed)
    {
        if (movingLeft)
        {
            spriteRenderer.flipX = false;
            return -mobSpeed;
        } else
        {
            spriteRenderer.flipX = true;
            return mobSpeed;
        }
    }

    // set enemy path
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RightEnemyPath")
        {
            movingLeft = true;
        }
        else if (collision.gameObject.tag == "LeftEnemyPath")
        {
            movingLeft = false;
        }
    }
}
