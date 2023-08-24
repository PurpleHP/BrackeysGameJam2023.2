using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeCinemachineScript : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cVC;
    [SerializeField] GreenBossRoom GreenBossRoom;
    [SerializeField] GreenBoss GreenBoss;
    public GameObject greenBoss;
    public GameObject submarine;
    private void Update()
    {
        if (GreenBossRoom.isOnGreenBoss)
        {
            cVC.m_Follow = greenBoss.transform;
            cVC.m_Lens.OrthographicSize = 13.5f;
        }
        if(GreenBoss.isDead)
        {
            cVC.m_Follow = submarine.transform;
            cVC.m_Lens.OrthographicSize = 5.6f;
        }
    }
    
}
