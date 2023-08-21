using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class LoadData : MonoBehaviour
{
    private int _totalCoins;
    [SerializeField] private TextMeshProUGUI _coinText;

    public void Update()
    {
        _totalCoins = PlayerPrefs.GetInt("Coins");
        _coinText.text = _totalCoins.ToString();
    }
}
