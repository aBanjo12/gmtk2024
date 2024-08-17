using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HazardMoveScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float speed = 0.1f;
    int deadZoneX = -20;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position + new Vector3(-speed, 0, 0);
        if (transform.position.x < deadZoneX)
        {
            Destroy(gameObject);
        }
    }
}
