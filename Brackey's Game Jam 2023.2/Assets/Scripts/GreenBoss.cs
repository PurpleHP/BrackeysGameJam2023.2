using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBoss : MonoBehaviour
{
    [SerializeField] BoxCollider2D box2d1;
    [SerializeField] BoxCollider2D box2d2;
    [SerializeField] BoxCollider2D triggeringEntry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D triggerEntry)
    {
        if (gameObject.CompareTag("Player"))
        {
            box2d1.isTrigger = false;
            box2d2.isTrigger = false;
        }
    }
}
