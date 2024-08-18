using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    Camera cam;
    public SpriteRenderer background;
    public scaleData scaleData;

    float scaleRatio;
    float startPos = 0;
    float endPos;
    float originalBackgroundWidth;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        transform.position = new Vector3(startPos, 0, 0);

        SetInitailScale();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3 (transform.position.x - 0f, 0, 0);

        endPos = -originalBackgroundWidth * scaleData.currentScale;

        //for (int i=0; transform.position.x <= endPos && i<100; i++)
        if (transform.position.x <= endPos)
        {
            float newPos = startPos - (endPos - transform.position.x);
            newPos %= endPos;
            transform.position = new Vector3(newPos, transform.position.y, 0);
        }

        transform.localScale = new Vector3(transform.localScale.x * scaleRatio, transform.localScale.y * scaleRatio, 1);

        Debug.Log(transform.localScale.x + ", " + transform.localScale.y);
    }

    void SetInitailScale()
    {
        float unitCamWidth;   
        unitCamWidth = cam.orthographicSize * 2f * cam.aspect;

        scaleRatio = 3 * unitCamWidth * background.sprite.pixelsPerUnit / background.sprite.texture.width;

        originalBackgroundWidth = scaleRatio * background.sprite.texture.width / background.sprite.pixelsPerUnit;
        endPos = -originalBackgroundWidth;

        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);
    }
}
