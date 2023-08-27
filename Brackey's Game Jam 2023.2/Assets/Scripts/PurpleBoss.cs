using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PurpleBoss : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneTransition;
    [SerializeField] CircleCollider2D purpleBoss1;
    [SerializeField] CircleCollider2D purpleBoss2;

    private Animator anim;
    [SerializeField] public float purpleBossHealth;
    [SerializeField] private GameObject submarine;

    [SerializeField] PlaySound sfx;


    private void Start()
    {
        anim = GetComponent<Animator>();
    
    }
    IEnumerator StartCutScene()
    {
        purpleBoss1.enabled = false;
        purpleBoss2.enabled = false;
        submarine.SetActive(false);
        anim.SetTrigger("IsDead");
        yield return new WaitForSeconds(0.5f);
        sfx.PlayBossDeath();
        yield return new WaitForSeconds(1.5f);
        sceneTransition.FinalScene();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            purpleBossHealth--;
            sfx.PlayEnemyHit();
            if (purpleBossHealth == 0)
            {
                PlayerPrefs.SetFloat("PurpleTrigger", 0);
                StartCoroutine(StartCutScene());
                
            }
        }
    }
}
