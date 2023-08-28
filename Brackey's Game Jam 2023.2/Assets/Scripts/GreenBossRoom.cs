using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossRoom : MonoBehaviour
{
    [SerializeField] PolygonCollider2D exit;
    [SerializeField] PolygonCollider2D enter;
    [SerializeField] PolygonCollider2D trigger;
    [SerializeField] PolygonCollider2D bulletBlocker;

    [SerializeField] GameObject greenBossRoom;

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
            isOnGreenBoss = true;
            enter.isTrigger = false;
            exit.isTrigger = false;
            bulletBlocker.enabled = false;
        }
    }

    private void Update()
    {
        if ((PlayerPrefs.GetInt("GreenTrigger") == 0) && !isOn)
        {
            trigger.enabled = false;
            enter.enabled = false;
            exit.enabled = false;
            isOn = true;
            greenBossRoom.SetActive(false);
        }
                
          
    }
}
