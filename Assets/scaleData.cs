using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleData : MonoBehaviour
{
    public float currentScale = 1f;
    public float minimumScale = .1f;
    public float scaleSpeed = .01f;
    public float scrollSpeed = .01f;

    private float originalSpeed;

    private void Start()
    {
        originalSpeed = scaleSpeed;
        
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        float toScale = 0;
        if (Input.GetKey(KeyCode.W))
            toScale += scaleSpeed;
        if (Input.GetKey(KeyCode.S))
            toScale -= scaleSpeed;

        if (currentScale + toScale >= minimumScale)
            currentScale += toScale;

        scrollSpeed = originalSpeed / currentScale;
    }
}
