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
        if(PlayerPrefs.HasKey("9.1") && PlayerPrefs.HasKey("9.2") && PlayerPrefs.HasKey("9.3"))
        {
            if(PlayerPrefs.GetInt("9.1") == 0 && PlayerPrefs.GetInt("9.2") == 0 && PlayerPrefs.GetInt("9.3") == 0)
            {
                room.isOnGreenBoss = false;
                PlayerPrefs.SetInt("GreeTrigger", 0);
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
        if (!PlayerPrefs.HasKey("GreenTrigger"))
        {
            PlayerPrefs.SetInt("GreeTrigger", 1);
        }
        else
        {
            Debug.Log("buradan dolayýdýr");
            PlayerPrefs.SetInt("GreeTrigger", 0);

        }
    }

    private void Update()
    {
        Debug.Log(room.isOnGreenBoss);
        Debug.Log(PlayerPrefs.GetInt("GreenTrigger"));

        if (PlayerPrefs.HasKey("9.1") && PlayerPrefs.HasKey("9.2") && PlayerPrefs.HasKey("9.3") && !isDone)
        {
            if (PlayerPrefs.GetInt("9.1") == 0 && PlayerPrefs.GetInt("9.2") == 0 && PlayerPrefs.GetInt("9.3") == 0)
            {
                Debug.Log("Bu yüzden 2");
                room.isOnGreenBoss = false;
                PlayerPrefs.SetInt("GreeTrigger", 0);
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
