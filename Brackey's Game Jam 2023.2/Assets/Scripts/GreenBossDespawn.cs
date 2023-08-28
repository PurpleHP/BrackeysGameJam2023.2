using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossDespawn : MonoBehaviour
{
    [SerializeField] GameObject GreenBoss;
    [SerializeField] GameObject GreenBossChild1;

    [SerializeField] GameObject GreenBossChild2;
    [SerializeField] GameObject GreenBossRoom;
    private bool isDone = false;

    [SerializeField] GreenBossRoom room;

    void Start()
    {

        if (PlayerPrefs.HasKey("9.1") && PlayerPrefs.HasKey("9.2") && PlayerPrefs.HasKey("9.3"))
        {
            if(PlayerPrefs.GetInt("9.1") == 2 && PlayerPrefs.GetInt("9.2") == 2 && PlayerPrefs.GetInt("9.3") == 2)
            {
                room.isOnGreenBoss = false;
                PlayerPrefs.SetInt("GreeTrigger", 2);
                Debug.Log(room.isOnGreenBoss);
            }
        }
        else
        {
            PlayerPrefs.SetInt("9.1", 1);
            PlayerPrefs.SetInt("9.2", 1);
            PlayerPrefs.SetInt("9.3", 1);
            PlayerPrefs.Save();

        }
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey("GreenTrigger"))
        {
            if(PlayerPrefs.GetInt("GreenTrigger") == 2)
            {
                GreenBoss.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("9.1") && PlayerPrefs.HasKey("9.2") && PlayerPrefs.HasKey("9.3") && !isDone)
        {
            if (PlayerPrefs.GetInt("9.1") == 2 && PlayerPrefs.GetInt("9.2") == 2 && PlayerPrefs.GetInt("9.3") == 2)
            {
                Debug.Log("Bu yüzden 2");
                room.isOnGreenBoss = false;
                PlayerPrefs.SetInt("GreeTrigger", 2);
                PlayerPrefs.Save();
                isDone = true;
            }
            else
            {
                PlayerPrefs.SetInt("GreeTrigger", 1);
                PlayerPrefs.SetInt("9.1", 1);
                PlayerPrefs.SetInt("9.2", 1);
                PlayerPrefs.SetInt("9.3", 1);
                PlayerPrefs.Save();

            }
        }
        else
        {
            PlayerPrefs.SetInt("GreeTrigger", 1);
            PlayerPrefs.SetInt("9.1", 1);
            PlayerPrefs.SetInt("9.2", 1);
            PlayerPrefs.SetInt("9.3", 1);
            PlayerPrefs.Save();

        }

    }
}
