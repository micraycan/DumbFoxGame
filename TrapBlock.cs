using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlock : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            // FindObjectOfType<AudioManager>().BlockBreakGround();
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().BlockBreak();
            rb.gravityScale = 20f;
        }
    }
}
