using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

public class move : MonoBehaviour
{
    public scaleData data;
    public Rigidbody2D rb;
    public Collider2D col;
    public CircleCollider2D circleCol;

    public TextMeshProUGUI GameOverText;
    public GameObject RetryButton;
    public GameObject Score;
    public GameObject PlatformHolder;
    public GameObject Background;

    public bool grounded = false;
    public float jumppower = 10;

    public bool dead = false;

    private List<RaycastHit2D> collisions = new();

    private float lastScale;

    private void Start()
    {
        lastScale = data.currentScale;
    }

    void FixedUpdate()
    {
        if (dead) return;
        transform.localScale = new Vector3(data.currentScale, data.currentScale);
        transform.position += new Vector3(0, grounded && (data.currentScale - lastScale) < 0 ? data.currentScale - lastScale : 0 , 0);
        lastScale = data.currentScale;
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            rb.AddForce(new Vector2(0, jumppower * data.currentScale), ForceMode2D.Impulse);
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
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("hazard") && !dead) 
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            EndGame();
        }
    }

    void EndGame()
    {
        string scoreStr = Score.GetComponent<TextMeshProUGUI>().text;
        GameOverText.text = "Game Over! \n" + scoreStr;

        Debug.Log(GameOverText.text);
        RetryButton.SetActive(true);
        Score.SetActive(false);

        PlatformHolder.GetComponent<scaleData>().scrollSpeed = 0;
        PlatformHolder.GetComponent<scaleData>().enabled = false;

        Background.GetComponent<scaleData>().scrollSpeed = 0;
        Background.GetComponent<scaleData>().enabled = false;

        dead = true;
    }
}
