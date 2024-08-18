using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEngine;

public class platformUpdate : MonoBehaviour
{
    public scaleData data;
    public float x, y;
    public float deadzone;
    Vector3 baseScale;
    // Start is called before the first frame update
    private void Start()
    {
        data = GameObject.FindGameObjectWithTag("PlatformHolder").GetComponent<scaleData>();
        baseScale = transform.localScale;
        DoScaleMath();
    }
    private void FixedUpdate()
    {
        DoScaleMath();
        if (x < deadzone) Destroy(gameObject);
    }

    void DoScaleMath()
    {
        x -= data.scrollSpeed;// data.scrollSpeed;
        //float xscaleratio = transform.localScale.x / transform.localScale.y;
        transform.localScale = new Vector3(data.currentScale * baseScale.x, data.currentScale * baseScale.y, 1);
        transform.position = new Vector3(x * data.currentScale, (y * data.currentScale - transform.localScale.y / 2) - (data.playerpos.position.y), 0);
    }
}
