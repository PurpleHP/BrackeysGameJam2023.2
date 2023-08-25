using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class DepthCalculator : MonoBehaviour
{

    [SerializeField] GameObject submarine;
    private float _depth;
    public int _intDepth;
    [SerializeField] private float _depthSpeed = 5f;
    [SerializeField] private TextMeshProUGUI _depthText;

    void Update()
    {
        _depth = (submarine.transform.position.y * _depthSpeed);
        _intDepth = (int)Math.Round(_depth);
        _depthText.text = _intDepth + " m";
    }
}
