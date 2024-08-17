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

    public bool grounded = false;
    public float jumppower = 10;

    private List<RaycastHit2D> collisions = new();
    
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
            grounded = false;
        }
        
        
        if (rb.Cast(new Vector2(0, -1), collisions, 0.01f) > 0)
        {
            grounded = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.otherCollider.tag);
        if (collision.collider.tag == "hazard") 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
