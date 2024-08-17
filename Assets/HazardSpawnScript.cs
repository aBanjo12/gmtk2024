using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardSpawnScript : MonoBehaviour
{
    public GameObject hazard;

    float timer = 0;
    int spawnRate = 60;

    int lowestPoint = 1;
    int highestPoint = 10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnHazard();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer++;
        if (timer > spawnRate)
        {
            SpawnHazard();
            timer = 0;
        }
    }

    void SpawnHazard()
    {
        Instantiate(hazard, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
