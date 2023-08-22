using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCoin : MonoBehaviour
{
    public int totalCoins;
    public int speedLevel; // maks 4, default 1
    public int flashLight = 0; //1 olabilir, default 0: Belki tutorial olarak aldýrýlabilir
    public int oxygenLevel; //maks 4, default 1
    public int weaponLevel = 1; //maks 3???

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
