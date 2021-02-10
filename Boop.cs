using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * fox boop opossum on head
 * then he ded
 * opossum boop fox on side
 * then he died
 */

public class Boop : MonoBehaviour
{
    public GameObject enemyDeath;

    private Rigidbody2D rb;
    private Animator animator;
    private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        game = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // offset enemyDeath object so it's on top of the enemy instead of the player
        Vector3 offset = new Vector3(0, -1f, 0);

        // player jump on top of enemy to kill
        if (collision.gameObject.tag == "EnemyTop")
        {
            FindObjectOfType<AudioManager>().EnemyHit();

            // insert enemy death animation at player location with offset
            Instantiate<GameObject>(enemyDeath, GetComponent<Transform>().transform.position + offset, Quaternion.Euler(0, 0, 0));

            // enemy is kill
            GameObject.Destroy(collision.gameObject.transform.parent.gameObject);

            // little jump after goomba stomping enemy
            rb.AddForce(new Vector2(0, GetComponent<PlayerController>().jumpPower) * 1.25f, ForceMode2D.Impulse);
        }

        // player gets hit from left or right of enemy
        // i could just do one collsion for left and right but i planned to knock the player back
        // i dont feel like redoing the movement to make it work so we'll stick with a mario like death
        if (collision.gameObject.tag == "EnemyLeft" ||
            collision.gameObject.tag == "EnemyRight")
        {
            animator.SetTrigger("isHurt");
            game.EndGame();
        }
    }
}
