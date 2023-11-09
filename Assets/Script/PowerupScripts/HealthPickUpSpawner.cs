using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUpSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private Transform tf;
    private GameObject spawnedPickiup;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // if spawned pickup is not there
        if (spawnedPickiup == null)
        {
            // and it is time to spawn time
            if (Time.time > nextSpawnTime)
            {
                // spawn the pickup and set the next time
                spawnedPickiup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // otherwise, the object still exists, so postpone to the spawn
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}
