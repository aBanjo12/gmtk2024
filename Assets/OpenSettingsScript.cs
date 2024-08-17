using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsScript : MonoBehaviour
{
    public GameObject startButton;
    public GameObject resolutionButton;
    public GameObject fullScreenButton;
    public GameObject backButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseSettings()
    {
        SetSettingsButtons(false);
        SetMainButtons(true);
    }
    public void OpenSettings()
    {
        SetMainButtons(false);
        SetSettingsButtons(true);
    }

    void SetMainButtons(bool b)
    {
        gameObject.SetActive(b);
        startButton.SetActive(b);
    }

    void SetSettingsButtons(bool b)
    {
        resolutionButton.SetActive(b);
        fullScreenButton.SetActive(b);
        backButton.SetActive(b);
    }
}
