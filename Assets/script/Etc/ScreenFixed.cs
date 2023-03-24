using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFixed : MonoBehaviour
{
    private void Start()
    {
        SetResolution();
    }

    private void SetResolution()
    {
        float targetAspectRatio = 9f / 16f;
        float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        if (currentAspectRatio > targetAspectRatio)
        {
            int targetHeight = Mathf.RoundToInt(Screen.width / targetAspectRatio);
            Screen.SetResolution(Screen.width, targetHeight, true);
        }
        else
        {
            int targetWidth = Mathf.RoundToInt(Screen.height * targetAspectRatio);
            Screen.SetResolution(targetWidth, Screen.height, true);
        }
    }
}
