using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class HazardSpawnScript : MonoBehaviour
{
    public GameObject[] platformArray;
    public Transform platformHolder;
    public BoxCollider2D collider;

    scaleData scaleData;
    //float platformWidth;


    // Start is called before the first frame update
    void Start()
    {
        scaleData = platformHolder.GetComponent<scaleData>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Last Spawned Platform")
        {
            GameObject platform = collision.gameObject;


            float colliderRightX = platform.transform.position.x + GetPlatformWidth(platform) * collision.transform.localScale.x * scaleData.currentScale / 2;
            float triggerLeftX = gameObject.transform.position.x - collider.size.x / 2;

            
            platform.transform.position = new Vector3(platform.transform.position.x + (triggerLeftX - colliderRightX), platform.transform.position.y, platform.transform.position.z);

            Debug.Log(triggerLeftX - colliderRightX);
            collision.tag = "Untagged";

            SpawnPlatform(triggerLeftX - colliderRightX);
        }
    }

    void SpawnPlatform(float offset)
    {
        GameObject platform = platformArray[0];//platformArray[Random.Range(0, platformArray.Length)];

        float halfPlatformWidth = GetPlatformWidth(platform) * platform.transform.localScale.x * scaleData.currentScale / 2;
        float spawnerLeftX = gameObject.transform.position.x - collider.size.x / 2;

        //platform.GetComponent<platformUpdate>().x = (spawnerLeftX + halfPlatformWidth) / scaleData.currentScale;
        //platform.GetComponent<platformUpdate>().y = 0;
        platform.tag = "Last Spawned Platform";
        Instantiate(platform, new Vector3(-100, -100, 0), transform.rotation, platformHolder);
        
    }

    float GetPlatformWidth(GameObject platform)
    {
       return platform.GetComponent<BoxCollider2D>().size.x;
    }
}
