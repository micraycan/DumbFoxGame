using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDialogue : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public BoxCollider2D playerBoxCollider2D;
    public DialogueTrigger dialogueTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // is collider touching the player
        if (boxCollider2D.IsTouching(playerBoxCollider2D) && Input.GetKeyDown(KeyCode.E))
        {
            dialogueTrigger.TriggerDialogue();
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerBoxCollider2D)
        {
            dialogueTrigger.TriggerDialogue();
        }
    }
    */
}
