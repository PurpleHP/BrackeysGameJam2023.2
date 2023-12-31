using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCinemachineScript : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cVC;
    [SerializeField] GreenBossRoom GreenBossRoom;

    [SerializeField] GreenBossMain GreenBoss;
    [SerializeField] GreenBoss GreenBossChild1;
    [SerializeField] GreenBoss GreenBossChild2;
    
    [SerializeField] 
    public GameObject greenBossPosition;


    [SerializeField] PurpleBossRoom PurpleBossRoom;

    public GameObject purpleBossPosition;

    public GameObject submarine;
    private void Update()
    {
        if (GreenBossRoom.isOnGreenBoss)
        {
            cVC.m_Follow = greenBossPosition.transform;
            cVC.m_Lens.OrthographicSize = 13.5f;
        }
        if(GreenBoss.isDead && GreenBossChild1.isDead && GreenBossChild2.isDead)
        {
            PlayerPrefs.SetInt("GreenTrigger", 2);
            cVC.m_Follow = submarine.transform;
            cVC.m_Lens.OrthographicSize = 5.6f;
        }
        if (PurpleBossRoom.isOnPurpleBoss)
        {
            cVC.m_Follow = purpleBossPosition.transform;
            cVC.m_Lens.OrthographicSize = 23f;
        }
    }
}
