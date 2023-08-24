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
    [SerializeField] private float _depthSpeed = 5f;
    [SerializeField] public int SubmarineHealth = 5;
    [SerializeField] private TextMeshProUGUI _healthText;

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
            StartCoroutine(WaitForCoolDown());
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && CanBeUsed)
        {
            StartCoroutine(WaitForCoolDown());
        }
    }


}
