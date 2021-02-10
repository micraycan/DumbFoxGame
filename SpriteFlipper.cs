using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // player sprite flipper based on input
        if (Input.GetAxisRaw("Horizontal") < -0.1)
        {
            spriteRenderer.flipX = true;
        } else if (Input.GetAxisRaw("Horizontal") > 0.1)
        {
            spriteRenderer.flipX = false;
        }
    }
}
