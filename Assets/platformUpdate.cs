using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class platformUpdate : MonoBehaviour
{
    public scaleData data;
    public float x, y;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        x -= data.scrollSpeed;
        float xscalesign = transform.localScale.x < 0 ? -1 : 1;
        float yscalesign = transform.localScale.y < 0 ? -1 : 1;
        float xscaleratio = transform.localScale.x / transform.localScale.y;
        transform.localScale = new Vector3(data.currentScale * xscaleratio, data.currentScale, 0);
        transform.position = new Vector3(x * transform.localScale.x - transform.localScale.x/2 * xscalesign, (y * transform.localScale.y - transform.localScale.y/2 * yscalesign) - data.playerpos.position.y, 0);
    }
}
