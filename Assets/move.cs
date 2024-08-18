using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class move : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D col;
    public CircleCollider2D circleCol;

    public bool grounded = false;
    public float jumppower = 10;

    public bool paused = false;

    private List<RaycastHit2D> collisions = new();
    
    void FixedUpdate()
    {
        if (paused) return;
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
            grounded = false;
        }
        
        if (circleCol.Cast(new Vector2(0, -1), new ContactFilter2D(), collisions, .01f) > 0)
        {
            grounded = true;
        }
        if (col.Cast(new Vector2(1, .5f), new ContactFilter2D(), collisions, 0.01f) > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        transform.position = new Vector3(0, transform.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("hazard")) 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
