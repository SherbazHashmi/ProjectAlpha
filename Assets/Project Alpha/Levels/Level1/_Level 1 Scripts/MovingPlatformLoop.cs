using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLoop : MonoBehaviour
{
    [SerializeField] private GameObject movingPlatform;
    [SerializeField] private GameObject platformSpawn;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float speed;

    private GameObject platformClone;

    private void Update()
    {
        spawnTimer += 1 * Time.deltaTime;
        PlatFormSpawner();
    }

    public void PlatFormSpawner()
    {
        if (spawnTimer >= timeToSpawn)
        {
            platformClone = Instantiate(movingPlatform, platformSpawn.transform.position, transform.rotation);
            spawnTimer = 0f;
        }               
    }
}
