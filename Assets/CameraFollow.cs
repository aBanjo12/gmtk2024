using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public scaleData data;
    
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.05f;
    private Vector3 velocity = Vector3.zero;

    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = Vector3.SmoothDamp(transform.position, new Vector3(target.position.x, target.position.y, 0) + offset, ref velocity, smoothTime);
        targetPosition.x = target.position.x;
        transform.position = targetPosition;
        camera.orthographicSize = 5 * data.currentScale;
    }
}
