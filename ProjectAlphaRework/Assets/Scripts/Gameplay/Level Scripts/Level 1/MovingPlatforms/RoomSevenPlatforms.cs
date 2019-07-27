using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSevenPlatforms : MonoBehaviour
{
    [SerializeField] private GameObject spawner;          //Sets Spawner Variable
    [SerializeField] private Transform shredder;          //Sets Soawner Variable
    [SerializeField] private GameObject movingPlatform;   //Sets platform Prefab variable

    [SerializeField] private float timeToSpawn;           //sets the time between spawn variable

    private GameObject platformClone;                     //creates clone for Moving Platform

    private void Start()
    {
        StartCoroutine(PlatformSpawner());                //starts the Instantiate Coroutine
    }

    /// <summary>
    /// Instantiates a Clone of moving platform and spawn at Spawner GameObject
    /// Spawn a new platform every 5 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator PlatformSpawner()
    {
        platformClone = Instantiate(movingPlatform, spawner.transform.position, Quaternion.identity);                  //instantiates Clone at given location

        yield return new WaitForSeconds(timeToSpawn);                                                                  // yields for 5 seconds

        StartCoroutine(PlatformSpawner());                                                                             //spawns another platform
    }
}
