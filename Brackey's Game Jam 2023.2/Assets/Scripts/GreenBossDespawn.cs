using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBossDespawn : MonoBehaviour
{
    [SerializeField] GameObject GreenBoss;
    [SerializeField] GameObject GreenBossChild1;

    [SerializeField] GameObject GreenBossChild2;
    [SerializeField] GameObject GreenBossTrigger;
    private bool isDone = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {
        if ((PlayerPrefs.HasKey("GreenBoss") && PlayerPrefs.HasKey("GreenBossChild1") && PlayerPrefs.HasKey("GreenBossChild2")) && !isDone)
        {
            if (PlayerPrefs.GetFloat("GreenBoss") == 0 && PlayerPrefs.GetFloat("GreenBossChild1") == 0 && PlayerPrefs.GetFloat("GreenBossChild2") == 0)
            {
                isDone = true;
                GreenBoss.SetActive(false);

                GreenBossChild1.SetActive(false);
                GreenBossChild2.SetActive(false);
                GreenBossTrigger.SetActive(false);

            }
            else
            {
                PlayerPrefs.SetFloat("GreenBoss", 1);
                PlayerPrefs.SetFloat("GreenBossChild1", 1);
                PlayerPrefs.SetFloat("GreenBossChild2", 1);
                PlayerPrefs.SetFloat("GreenTrigger", 1);
                PlayerPrefs.Save();
            }

        }
        else
        {
            PlayerPrefs.SetFloat("GreenBoss", 1);
            PlayerPrefs.SetFloat("GreenBossChild1", 1);
            PlayerPrefs.SetFloat("GreenBossChild2", 1);
            PlayerPrefs.SetFloat("GreenTrigger", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("GreenBoss") + " GreenBoss. 1 olursa yaþýyor 0 olursa ölmüþ");
        Debug.Log(PlayerPrefs.GetFloat("GreenBoss1") + " GreenBossChild1. 1 olursa yaþýyor 0 olursa ölmüþ");
        Debug.Log(PlayerPrefs.GetFloat("GreenBoss2") + " GreenBossChild2. 1 olursa yaþýyor 0 olursa ölmüþ");

        if ((PlayerPrefs.HasKey("GreenBoss") && PlayerPrefs.HasKey("GreenBossChild1") && PlayerPrefs.HasKey("GreenBossChild2")) && !isDone)
        {
            if (PlayerPrefs.GetFloat("GreenBoss") == 0 && PlayerPrefs.GetFloat("GreenBossChild1") == 0 && PlayerPrefs.GetFloat("GreenBossChild2") == 0)
            {
                PlayerPrefs.SetFloat("GreenTrigger", 0);
                PlayerPrefs.Save();
                isDone = true;
                GreenBoss.SetActive(false);

                GreenBossChild1.SetActive(false);
                GreenBossChild2.SetActive(false);
                GreenBossTrigger.SetActive(false);

            }

        }
    }
}
