using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource jumpSound;
    public AudioSource enemyHit;
    public AudioSource collectGem;
    public AudioSource blockBreak;
    public AudioSource blockBreakGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JumpSound()
    {
        jumpSound.Play();
    }

    public void EnemyHit()
    {
        enemyHit.Play();
    }

    public void CollectGem()
    {
        collectGem.Play();
    }

    public void BlockBreak()
    {
        blockBreak.Play();
    }

    public void BlockBreakGround()
    {
        blockBreakGround.Play();
    }
}
