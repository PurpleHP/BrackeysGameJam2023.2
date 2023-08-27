using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossRoom : MonoBehaviour
{
    [SerializeField] PolygonCollider2D exit;
    [SerializeField] PolygonCollider2D enter;
    [SerializeField] PolygonCollider2D trigger;

    [SerializeField] GreenBossMain greenBoss;
    public bool isOnGreenBoss = false;
    private bool isOn = false;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("GreenTrigger", 1);
            PlayerPrefs.Save();
            isOnGreenBoss = true;
            enter.isTrigger = false;
            exit.isTrigger = false;
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("GreenTrigger") == 0)
        {
            trigger.enabled = false;
            enter.enabled = false;
            exit.enabled = false;
            gameObject.SetActive(false);
        }
                
          
    }
}
