using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour
{
    float startPos = 0;
    float endPos = -19.21f;
    float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(startPos, 0, 0);
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
