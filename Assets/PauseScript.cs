using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public scaleData background;
    public scaleData PlatformHolder;
    public GameObject ResumeButton;
    public GameObject Player;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
            
        }
    }

    public void Pause()
    {
        ResumeButton.SetActive(true);
        Debug.Log(Time.timeScale);
        Time.timeScale = 0;
        paused = true;
    }

    public void UnPause()
    {
        ResumeButton.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
}
