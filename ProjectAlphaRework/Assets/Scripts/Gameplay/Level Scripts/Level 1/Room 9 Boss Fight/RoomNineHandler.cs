using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNineHandler : MonoBehaviour
{
    [Header ("Conveyor")]
    [SerializeField] private GameObject leftSpawner;                                                                  //Sets Spawner Variable
    [SerializeField] private GameObject rightSpawner;                                                                  //Sets Spawner Variable
    [SerializeField] private GameObject ConveyorBelt;                                                                 //Sets platform Prefab variable

    [SerializeField] private float timeToSpawn;                                                                       //sets the time between spawn variable

    private GameObject platformClone;                                                                                 //creates clone for Moving Platform

    private void Start()
    {
        StartCoroutine(ConveyorSpawner());                                                                            //starts the Instantiate Coroutine
    }

    /// <summary>
    /// Instantiates a Clone of moving platform and spawn at Spawner GameObject
    /// Spawn a new platform every 5 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator ConveyorSpawner()
    {
        platformClone = Instantiate(ConveyorBelt, leftSpawner.transform.position, Quaternion.identity);                //instantiates Clone at given location

        yield return new WaitForSeconds(timeToSpawn);                                                                  // yields for 5 seconds

        StartCoroutine(ConveyorSpawner());                                                                             //spawns another platform
    }
}
