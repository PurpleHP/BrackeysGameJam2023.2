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
    public GameObject greenBossPosition;
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
            cVC.m_Follow = submarine.transform;
            cVC.m_Lens.OrthographicSize = 5.6f;
        }
    }
    
}
