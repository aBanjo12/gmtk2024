using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeResolutionScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public bool fullscreen;

    int[][] resolutions;
    int index = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        resolutions = new int[7][];
        resolutions[0] = new int[2] { 640, 480 };
        resolutions[1] = new int[2] { 800, 600 };
        resolutions[2] = new int[2] { 1024, 768 };
        resolutions[3] = new int[2] { 1280, 720 };
        resolutions[4] = new int[2] { 1440, 900 };
        resolutions[5] = new int[2] { 1920, 1080 };
        resolutions[6] = new int[2] { 2560, 1440 };

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (Screen.currentResolution.width == resolutions[i][0] && Screen.currentResolution.height == resolutions[i][1])
            {
                index = i;
            }
        }

        setText();
    }

    public void CycleResolution()
    {
        index++;
        
        if (index == resolutions.Length) index = 0;

        Screen.SetResolution(resolutions[index][0], resolutions[index][1], Screen.fullScreen);
        setText();
    }

    void setText()
    {
        text.text = resolutions[index][0] + "x" + resolutions[index][1];
    }
}
