using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip enemyHit, bulletSound, enemyDeath, playerHit, playerDeath, bossDeath, coinCollect;
    // Start is called before the first frame update
    public void PlayEnemyHit()//tamamland�
    {
        src.clip = enemyHit;
        src.Play();
    }
    public void PlayBullet() //tamamland�
    {
        src.clip = bulletSound;
        src.Play();
    }
    public void PlayEnemyDeath()//tamamland�
    {
        src.clip = enemyDeath;
        src.Play();
    }
    public void PlayPlayerGotHit() //tamamland�
    {
        src.clip = playerHit;
        src.Play();
    }
    public void PlayDeath()
    {
        src.clip = playerDeath;
        src.Play();
    }
    public void PlayCoin()
    {
        src.clip = coinCollect;
        src.Play();
    }
    public void BossDeath()
    {
        src.clip = bossDeath;
        src.Play();
    }
}
