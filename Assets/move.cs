using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class move : MonoBehaviour
{
    public Transform transform;
    public Rigidbody2D rb;

    public bool grounded = false;
    public float jumpForce = 10f;
    public float gravity = .1f;
    public float speedcap = 10f;

    public float speed = 0f;
    public float acceleration = 0f;

    private List<RaycastHit2D> collisions = new();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        



        if (rb.Cast(new Vector2(0, -1), collisions, 0.1f) > 0 && acceleration < 0)
        {
            grounded = true;
            speed = 0;
            acceleration = 0;
        }
        else
        {
            rb.MovePosition(new Vector2(0, speed));
        }
        
        if (!grounded)
        {
            acceleration -= gravity;
            speed += acceleration;
            // if (speed > speedcap)
            // {
            //     speed = speedcap;
            // }
            speed *= Time.fixedDeltaTime;
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                acceleration = jumpForce;
                grounded = false;
            }
        }
        

        
    }
}
