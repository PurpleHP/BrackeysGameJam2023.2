using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleBossRoom : MonoBehaviour
{
    public bool isOnPurpleBoss = false;
    //[SerializeField] PolygonCollider2D exit;
    [SerializeField] BoxCollider2D enter;


    void Update()
    {
        if (PlayerPrefs.HasKey("PurpleTrigger"))
        {
            if (PlayerPrefs.GetInt("PurpleTrigger") == 0)
            {
                enter.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnPurpleBoss = true;
            if (PlayerPrefs.GetInt("PurpleTrigger") != 0)
            {
                enter.isTrigger = false;

            }

        }
    }
}
