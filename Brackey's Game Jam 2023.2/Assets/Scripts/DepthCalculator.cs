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
    private int _intDepth;
    private float _depthSpeed;
    [SerializeField] private TextMeshProUGUI _depthText;

    private void Start()
    {
        
    }
    void Update()
    {
        _depth = (submarine.transform.position.y * _depthSpeed);
        _intDepth = (int)Math.Round(_depth);
        _depthText.text = _intDepth + " m";
    }
}
