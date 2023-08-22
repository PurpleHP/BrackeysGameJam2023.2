using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    //Oxygen ***************

    [SerializeField] SaveCoin coinScript;
    private int[] oxygenLevelCost = {0, 2, 4, 6};
    [SerializeField] private TextMeshProUGUI _oxygenLevelText;
    [SerializeField] private TextMeshProUGUI _oxygenPriceText;
    [SerializeField] private Image _oxygenCoinImage;
    [SerializeField] private Image _oxygenLevelImage;
    [SerializeField] private Image[] oxygenLevelImages;

    //Oxygen ***************

    //----------------------------------
    void Start()
    {
        //Oxygen ***************
        if ((PlayerPrefs.HasKey("Oxygen")))
        {
             coinScript.oxygenLevel = PlayerPrefs.GetInt("Oxygen");
            _oxygenLevelImage.sprite = oxygenLevelImages[coinScript.oxygenLevel - 1].sprite;

        }
        else
        {
            coinScript.oxygenLevel = 1;
            _oxygenLevelImage.sprite = oxygenLevelImages[0].sprite;

        }
        //Oxygen ***************

        //----------------------------------


    }

    public void CanBuyOxygen()
    {
        if(coinScript.oxygenLevel < 4)
        {
            if (coinScript.totalCoins >= oxygenLevelCost[coinScript.oxygenLevel])
            {
                PlayerPrefs.SetInt("Coins", coinScript.totalCoins - oxygenLevelCost[coinScript.oxygenLevel]);
                coinScript.oxygenLevel++;
                PlayerPrefs.SetInt("Oxygen", coinScript.oxygenLevel);
            }
        }
        
    }
    public void Update()
    {
        //Oxygen ***************
        _oxygenLevelText.text = "Oxygen Tank Level: " + coinScript.oxygenLevel;
        if(coinScript.oxygenLevel > 1)
        {
            Debug.Log("1den büyük");
            _oxygenLevelImage.sprite = oxygenLevelImages[coinScript.oxygenLevel - 1].sprite;
        }
        else
        {
            Debug.Log("1 þuan");

            _oxygenLevelImage.sprite = oxygenLevelImages[0].sprite;
        }
        
        if (coinScript.oxygenLevel == 4)
        {
            _oxygenCoinImage.enabled = false;
            _oxygenPriceText.text = "Your Oxygen Level Is At Max";
        }
        else
        {
            _oxygenPriceText.text = "Buy For " + oxygenLevelCost[coinScript.oxygenLevel];
        }
        //Oxygen ***************


        //----------------------------------
    }

}
