using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPrefs : MonoBehaviour
{
    [SerializeField] private float objectId;

    private void Start()
    {
        if (PlayerPrefs.HasKey($"{objectId}"))
        {
            if(PlayerPrefs.GetInt($"{objectId}") == 1)
            {
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
