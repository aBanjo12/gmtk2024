using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    Camera cam;
    public SpriteRenderer background;
    public scaleData data;
    public float scrollSpeedRatio = 0.5f;
    public float startY;
    public bool useInitialScaleSetter = false;
    

    float scaleRatio;
    float startPos = 0;
    float endPos;
    float originalBackgroundWidth;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        transform.position = new Vector3(startPos, startY, 5);
        if (useInitialScaleSetter)
            SetInitailScale();
        else
        {
            originalBackgroundWidth = 8 * background.sprite.texture.width / background.sprite.pixelsPerUnit;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x - data.scrollSpeed * scrollSpeedRatio, transform.position.y, transform.position.z);

        endPos = -originalBackgroundWidth;

        //for (int i=0; transform.position.x <= endPos && i<100; i++)
        if (transform.position.x <= endPos)
        {
            float newPos = startPos - (endPos - transform.position.x);
            newPos %= endPos;
            transform.position = new Vector3(newPos, transform.position.y, transform.position.z);
        }
    }

    void SetInitailScale()
    {
        float unitCamWidth;   
        unitCamWidth = cam.orthographicSize * 2f * cam.aspect;

        scaleRatio = unitCamWidth * background.sprite.pixelsPerUnit / background.sprite.texture.width;

        originalBackgroundWidth = scaleRatio * background.sprite.texture.width / background.sprite.pixelsPerUnit;
        endPos = -originalBackgroundWidth;

        transform.localScale = new Vector3(scaleRatio, scaleRatio, 1);
    }
}
