using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    [SerializeField] SaveCoin coinScript;

    [SerializeField] Health submarineHealth;

    //Oxygen ***************

    private int[] oxygenLevelCost = {0, 2, 4, 6};
    [SerializeField] private TextMeshProUGUI _oxygenLevelText;
    [SerializeField] private TextMeshProUGUI _oxygenPriceText;
    [SerializeField] private Image _oxygenCoinImage;
    [SerializeField] private Image _oxygenLevelImage;
    [SerializeField] private Image[] OxygenLevelImages;

    //Oxygen ***************

    //Speed ***************

    private int[] speedLevelCost = { 0, 3, 5, 7 };
    private int[] realSpeed = { 6, 7, 8, 10 }; //SaveCoin'dan da deðiþtirilmeli
    [SerializeField] private TextMeshProUGUI _speedLevelText;
    [SerializeField] private TextMeshProUGUI _speedPriceText;
    [SerializeField] private Image _speedCoinImage;
    [SerializeField] private Image _speedLevelImage;
    [SerializeField] private Image[] SpeedLevelImages;

    //Speed **************

    private int[] hpLevelCost = { 0, 3, 5, 7 };
    private int[] realHP = { 6, 7, 8, 10 }; //SaveCoin'dan da deðiþtirilmeli
    [SerializeField] private TextMeshProUGUI _hpLevelText;
    [SerializeField] private TextMeshProUGUI _hpPriceText;
    [SerializeField] private Image _hpCoinImage;
    [SerializeField] private Image _hpLevelImage;
    [SerializeField] private Image[] HPLevelImages;


    //----------------------------------
    void Start()
    {
        //Oxygen ***************
        if ((PlayerPrefs.HasKey("Oxygen")))
        {
             coinScript.oxygenLevel = PlayerPrefs.GetInt("Oxygen");
            _oxygenLevelImage.sprite = OxygenLevelImages[coinScript.oxygenLevel - 1].sprite;

        }
        else
        {
            coinScript.oxygenLevel = 1;
            _oxygenLevelImage.sprite = OxygenLevelImages[0].sprite;

        }
        //Oxygen ***************

        //----------------------------------

        //Speed ***************

        if ((PlayerPrefs.HasKey("SpeedLevel")))
        {
            coinScript.speedLevel = PlayerPrefs.GetInt("SpeedLevel");
            _speedLevelImage.sprite = OxygenLevelImages[coinScript.speedLevel - 1].sprite;

        }
        else
        {
            coinScript.speedLevel = 1;
            _speedLevelImage.sprite = OxygenLevelImages[0].sprite;

        }
        if ((PlayerPrefs.HasKey("Speed")))
        {
            coinScript.realSpeed = PlayerPrefs.GetInt("Speed");

        }
        else
        {
            coinScript.realSpeed = realSpeed[0];

        }

        //Speed ***************

        if ((PlayerPrefs.HasKey("HP")))
        {
            coinScript.speedLevel = PlayerPrefs.GetInt("HPLevel");
            _hpLevelImage.sprite = HPLevelImages[coinScript.hpLevel - 1].sprite;

        }
        else
        {
            coinScript.speedLevel = 1;
            _speedLevelImage.sprite = OxygenLevelImages[0].sprite;

        }
        if ((PlayerPrefs.HasKey("Speed")))
        {
            coinScript.realSpeed = PlayerPrefs.GetInt("Speed");

        }
        else
        {
            coinScript.realSpeed = realSpeed[0];

        }
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
    public void CanBuySpeed()
    {
        if (coinScript.speedLevel < 4)
        {
            if (coinScript.totalCoins >= speedLevelCost[coinScript.speedLevel])
            {
                PlayerPrefs.SetInt("Coins", coinScript.totalCoins - speedLevelCost[coinScript.speedLevel]);
                coinScript.speedLevel++;
                coinScript.realSpeed = realSpeed[coinScript.speedLevel - 1];
                PlayerPrefs.SetInt("SpeedLevel", coinScript.speedLevel);
                PlayerPrefs.SetInt("Speed", coinScript.realSpeed);

            }
        }
    }

    public void CanBuyHP()
    {
        if (coinScript.hpLevel < 4)
        {
            if (coinScript.totalCoins >= hpLevelCost[coinScript.hpLevel])
            {
                PlayerPrefs.SetInt("Coins", coinScript.totalCoins - hpLevelCost[coinScript.hpLevel]);
                coinScript.hpLevel++;
                coinScript.realHP = realHP[coinScript.hpLevel - 1];
                PlayerPrefs.SetInt("HPLevel", coinScript.hpLevel);
                PlayerPrefs.SetInt("HP", coinScript.realHP);

            }
        }
    }




    public void Update()
    {
        //Oxygen ***************

        _oxygenLevelText.text = "Oxygen Tank Level: " + coinScript.oxygenLevel;
        if(coinScript.oxygenLevel > 1)
        {
            _oxygenLevelImage.sprite = SpeedLevelImages[coinScript.oxygenLevel - 1].sprite;
        }
        else
        {

            _oxygenLevelImage.sprite = SpeedLevelImages[0].sprite;
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

        //Speed ***************
        _speedLevelText.text = "Speed Level: " + coinScript.speedLevel;
        if (coinScript.speedLevel > 1)
        {
            _speedLevelImage.sprite = SpeedLevelImages[coinScript.speedLevel - 1].sprite;
        }
        else
        {
            _speedLevelImage.sprite = SpeedLevelImages[0].sprite;
        }

        if (coinScript.speedLevel == 4)
        {
            _speedCoinImage.enabled = false;
            _speedPriceText.text = "Your Speed Level Is At Max";
        }
        else
        {
            _speedPriceText.text = "Buy For " + speedLevelCost[coinScript.speedLevel];
        }
        //Speed ***************

        //----------------------------------
        _hpLevelText.text = "Speed Level: " + coinScript.speedLevel;
        if (coinScript.hpLevel > 1)
        {
            _hpLevelImage.sprite = HPLevelImages[coinScript.hpLevel - 1].sprite;
        }
        else
        {
            _hpLevelImage.sprite = HPLevelImages[0].sprite;
        }

        if (coinScript.hpLevel == 4)
        {
            _hpCoinImage.enabled = false;
            _hpPriceText.text = "Your Speed Level Is At Max";
        }
        else
        {
            _hpPriceText.text = "Buy For " + hpLevelCost[coinScript.hpLevel];
        }

    }
}
