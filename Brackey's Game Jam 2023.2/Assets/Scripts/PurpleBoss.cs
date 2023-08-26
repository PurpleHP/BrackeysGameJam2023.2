using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBoss : MonoBehaviour
{
    [SerializeField] public float purpleBossHealth;


    void Start()
    {
        
    }

    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            purpleBossHealth--;
        }
    }
}
