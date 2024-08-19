using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using JetBrains.Annotations;
using UnityEngine;

public class platformUpdate : MonoBehaviour
{
    public scaleData data;
    public float deadzone;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position -= new Vector3(data.scrollSpeed, 0, 0);// data.scrollSpeed;
        if (transform.position.x < deadzone) Destroy(gameObject);
    }
}
