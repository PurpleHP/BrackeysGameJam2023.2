using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CoinSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SaveCoin coinScript;
    private int[] oxygenLevelCost = {0, 10, 20};
    [SerializeField] private TextMeshProUGUI _oxygenLevelText;
    [SerializeField] private TextMeshProUGUI _oxygenPriceText;
    [SerializeField] private Image _oxygenCoinImage;

    void Start()
    {
        if ((PlayerPrefs.HasKey("Oxygen")))
        {
             coinScript.oxygenLevel = PlayerPrefs.GetInt("Oxygen");

        }
        else
        {
            coinScript.oxygenLevel = 1;
        }
    }

    public void CanBuyOxygen()
    {
        if(coinScript.totalCoins >= oxygenLevelCost[coinScript.oxygenLevel])
        {
            PlayerPrefs.SetInt("Coins", coinScript.totalCoins - oxygenLevelCost[coinScript.oxygenLevel]);
            coinScript.oxygenLevel++;
            PlayerPrefs.SetInt("Oxygen", coinScript.oxygenLevel);
        }
    }
    public void Update()
    {
        _oxygenLevelText.text = "Oxygen Tank Level: " + coinScript.oxygenLevel;
        if (coinScript.oxygenLevel == 3)
        {
            _oxygenCoinImage.enabled = false;
            _oxygenPriceText.text = "Your Oxygen Level Is At Max";
        }
        else
        {
            _oxygenPriceText.text = "Buy For " + oxygenLevelCost[coinScript.oxygenLevel];
        }
    }

}
