using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCoin : MonoBehaviour
{
    public int totalCoins;
    public int speedLevel; // maks 4, default 1
    public int realSpeed;
    public int hpLevel;
    public int realHP;
    private int[] realSpeedList = { 6, 7, 8, 10 };
    private int[] realHPList = { 3, 4, 5, 6 };

    [SerializeField] Health health;

    //public int flashLight = 0; //1 olabilir, default 0: Belki tutorial olarak aldýrýlabilir
    public int oxygenLevel; //maks 4, default 1
    //public int weaponLevel = 1; //maks 3???

    private void Start()
    {
        if((PlayerPrefs.HasKey("Coins")))
        {
            totalCoins = PlayerPrefs.GetInt("Coins");

        }
        else
        {
            totalCoins = 0;
        }
        if((PlayerPrefs.HasKey("Speed")))
        {
            realSpeed = PlayerPrefs.GetInt("Speed");

        }
        else
        {
            realSpeed = realSpeedList[0];
        }
        if ((PlayerPrefs.HasKey("Oxygen")))
        {
            oxygenLevel = PlayerPrefs.GetInt("Oxygen");

        }
        else
        {
            oxygenLevel = 1;
        }
        if ((PlayerPrefs.HasKey("HP")))
        {
            realHP = PlayerPrefs.GetInt("HP");
            health.SubmarineHealth = realHP;
        }
        else
        {
            realHP = realHPList[0];
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            totalCoins += 1;
            PlayerPrefs.SetInt("Coins", totalCoins);
        }
    }
}
