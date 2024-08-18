using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    Camera cam;
    public SpriteRenderer background;

    float scaleRatio;
    float startPos = 0;
    float endPos = -19.21f;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPos, 0, 0);

        cam = Camera.main;
        float unitCamWidth = cam.orthographicSize * 2f * cam.aspect;

        endPos = -unitCamWidth;
        
        scaleRatio = unitCamWidth * background.sprite.pixelsPerUnit / background.sprite.texture.width;
        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (transform.position.x - speed, 0, 0);
        if (transform.position.x <= endPos)
        {
            transform.position = new Vector3(startPos - (endPos - transform.position.x), 0, 0);
        }
    }
}
