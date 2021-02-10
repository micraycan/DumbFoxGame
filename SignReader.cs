using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignReader : MonoBehaviour
{
    public GameObject player;
    public GameObject textBox;
    public Text text;
    public BoxCollider2D boxCollider2D;
    public string signText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boxCollider2D.IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            // show text box
            animator.SetBool("isOpen", true);
            text.text = signText;
        } else
        {
            // hide text box
            animator.SetBool("isOpen", false);
        }
    }
}
