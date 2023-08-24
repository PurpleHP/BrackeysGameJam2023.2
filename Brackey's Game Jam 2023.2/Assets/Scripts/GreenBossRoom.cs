using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossRoom : MonoBehaviour
{
    [SerializeField] PolygonCollider2D exit;
    [SerializeField] PolygonCollider2D enter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enter.isTrigger = false;
            exit.isTrigger = false;
        }
    }
}
