using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleData : MonoBehaviour
{
    public float currentScale = 1f;
    public float minScale;
    public float maxScale;
    public float scaleSpeed;
    public float scrollSpeed;
    public Transform playerpos;

    private float originalSpeed;

    private void Start()
    {
        originalSpeed = scrollSpeed;
    }

    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            currentScale /= 0.9f;
        if (Input.GetKey(KeyCode.S))
            currentScale *= 0.9f;

        if (currentScale < minScale)
            currentScale = minScale;
        else if (currentScale > maxScale)
            currentScale = maxScale;

        scrollSpeed = currentScale * originalSpeed;
    }
}
