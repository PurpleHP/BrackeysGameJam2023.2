using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBossRoom : MonoBehaviour
{
    public bool isOnPurpleBoss = false;
    //[SerializeField] PolygonCollider2D exit;
    [SerializeField] BoxCollider2D enter;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnPurpleBoss = true;
            enter.isTrigger = false;
            //exit.isTrigger = false;
        }
    }
}
