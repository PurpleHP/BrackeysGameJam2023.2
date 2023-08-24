using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossRoom : MonoBehaviour
{
    [SerializeField] PolygonCollider2D exit;
    [SerializeField] PolygonCollider2D enter;
    public bool isOnGreenBoss = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnGreenBoss = true;
            enter.isTrigger = false;
            exit.isTrigger = false;
        }
    }
}
