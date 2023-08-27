using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    [SerializeField] private float objectId;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(objectId != 0)
            {
                PlayerPrefs.SetInt($"{objectId}", 0);
            }
            Destroy(gameObject);
        }
    }
}