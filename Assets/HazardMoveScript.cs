using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardMoveScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float speed = 5f;
    int deadZoneX = -20;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = new Vector2(-speed, 0);
        rigidBody.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < deadZoneX)
        {
            Destroy(gameObject);
        }
    }
}
