using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashLight;
    private bool isFlashLightOpen;

    private void Update()
    {
        changeflashlightState();
    }
    void changeflashlightState()
    {
        if (Input.GetKeyDown(KeyCode.F) && isFlashLightOpen)
        {
            flashLight.SetActive(false);
            isFlashLightOpen = !isFlashLightOpen;
        }
        else if (Input.GetKeyDown(KeyCode.F) && !isFlashLightOpen)
        {
            flashLight.SetActive(true);
            isFlashLightOpen = true;
        }
    }
}
