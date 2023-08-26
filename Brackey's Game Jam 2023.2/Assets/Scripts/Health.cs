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
    [SerializeField] public int SubmarineHealth = 5;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] float pushForce;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _healthText.text = SubmarineHealth + " HP";
        if(SubmarineHealth <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
    private bool CanBeUsed = true;

    IEnumerator WaitForCoolDown()
    {
        CanBeUsed = false;
        SubmarineHealth--;
        yield return new WaitForSeconds(1);
        CanBeUsed = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && CanBeUsed)
        {
            rb.AddForce(-1 * gameObject.transform.forward * pushForce);
            StartCoroutine(WaitForCoolDown());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && CanBeUsed)
        {
            rb.AddForce(-1 * gameObject.transform.forward * pushForce);
            StartCoroutine(WaitForCoolDown());
        }
    }
}