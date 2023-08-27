using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
            Debug.Log("Screen Changed");
        }
    }
    public void Change()
    {
        Screen.fullScreen = !Screen.fullScreen;
        Debug.Log("Screen Changed");
    }
}
