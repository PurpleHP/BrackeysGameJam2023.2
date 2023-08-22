using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetMoneyTest : MonoBehaviour
{
    [SerializeField] private Image _oxygenCoinImage;
    public void ResetOxygen()
    {
        PlayerPrefs.DeleteKey("Oxygen");
        _oxygenCoinImage.enabled = true;
    }
    public void ResetSpeed()
    {
        PlayerPrefs.DeleteKey("Speed");
        _oxygenCoinImage.enabled = true;
    }
    public void ResetCoin()
    {
        PlayerPrefs.DeleteKey("Coins");
    }
    public void Billionaire()
    {
        PlayerPrefs.SetInt("Coins", 3169);
    }

    public void DeleteEveryKey()
    {
        PlayerPrefs.DeleteAll();
    }
}
