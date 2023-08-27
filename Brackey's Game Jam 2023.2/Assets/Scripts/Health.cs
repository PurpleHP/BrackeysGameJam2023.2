using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject submarine;
    [SerializeField] public int SubmarineHealth;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] float pushForce;
    private Rigidbody2D rb;

    [SerializeField] PlaySound sfx;

    private bool isDead = false;
    [SerializeField] SceneManagerScript sceneTransition;


    private int[] realHP = { 3,4,5,6 };
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (PlayerPrefs.HasKey("HP"))
        {
            SubmarineHealth = PlayerPrefs.GetInt("HP");
        }
        else
        {
            SubmarineHealth = realHP[0];
        }
    }
    void Update()
    {
        _healthText.text = SubmarineHealth.ToString();
        if(SubmarineHealth == 0 && !isDead)
        {
            isDead = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            sceneTransition.PlayerDeath();

        }
    }
    private bool CanBeUsed = true;

    IEnumerator WaitForCoolDown()
    {
        CanBeUsed = false;
        SubmarineHealth--;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(1);
        CanBeUsed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("Projectile")) && CanBeUsed && SubmarineHealth > 0)
        {
            sfx.PlayPlayerGotHit();
            //rb.AddForce(-1 * gameObject.transform.forward * pushForce);
            StartCoroutine(WaitForCoolDown());
        }
        else if (collision.CompareTag("Coin"))
        {
            sfx.PlayCoin();
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.CompareTag("Enemy") || collision.CompareTag("Projectile")) && CanBeUsed && SubmarineHealth > 0)
        {
            sfx.PlayPlayerGotHit();
            //rb.AddForce(-1 * gameObject.transform.forward * pushForce);
            StartCoroutine(WaitForCoolDown());
        }
    }
}