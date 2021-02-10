using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    public BoxCollider2D door;
    public Transform spawnPoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (door.IsTouching(player.GetComponent<BoxCollider2D>()) && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, player.transform.position.z);
        }
    }
}
