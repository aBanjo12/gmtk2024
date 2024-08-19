using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowX : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform t;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(t.position.x, transform.position.y, transform.position.z);
    }
}
