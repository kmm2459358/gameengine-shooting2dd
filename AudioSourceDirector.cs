using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceDirector : MonoBehaviour
{
    public AudioClip dead;
    public AudioClip hit;
    public AudioClip ko;
    public AudioClip shot;
    public AudioClip hp;
    public AudioClip ult;
    public AudioClip war;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    public void PlayerDead()
    {
        audioSource.PlayOneShot(dead);
    }

    public void PlayerHit()
    {
        audioSource.PlayOneShot(hit);
    }

    public void EnemyKO()
    {
        audioSource.PlayOneShot(ko);
    }

    public void EnemyShot()
    {
        audioSource.PlayOneShot(shot);
    }

    public void PlayerHP()
    {
        audioSource.PlayOneShot(hp);
    }

    public void PlayerUlt()
    {
        audioSource.PlayOneShot(ult);
    }

    public void Warning()
    {
        audioSource.PlayOneShot(war);
    }
}
