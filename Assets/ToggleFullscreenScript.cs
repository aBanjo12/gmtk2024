using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleFullscreenScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    bool fullScreen;
    // Start is called before the first frame update
    void Start()
    {
        fullScreen = Screen.fullScreen;
        UpdateText();
    }

    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        fullScreen = !Screen.fullScreen;
        UpdateText();
    }

    void UpdateText()
    {
        if (fullScreen)
        {
            text.text = "Fullscreen [X]";
        }
        else
        {
            text.text = "Fullscreen [ ]";
        }
    }
}
