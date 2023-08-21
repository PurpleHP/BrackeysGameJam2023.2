using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCoin : MonoBehaviour
{
    public int totalCoins;
    public int flashLight = 0; //1 olabilir
    public int oxygenLevel = 1; //maks 3
    public int weaponLevel = 1; //maks 3

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
            Debug.Log(totalCoins);
            totalCoins += 1;
            PlayerPrefs.SetInt("Coins", totalCoins);
        }
    }
}
