//*****************************
//This script is for Room FIVE
//*****************************
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelEnterCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cutScenePanel;      //Deactivates player Controls
    [SerializeField] private GameObject spawnerOne;         //First Enemy Spawner
    [SerializeField] private GameObject spawnerTwo;         //Second Enemy Spawner
    [SerializeField] private GameObject moveToPositionOne;  //First enemy move to position
    [SerializeField] private GameObject moveToPositionTwo;  //second enemy move to position
 
    [SerializeField] private Transform enemyOne;            //First enemy prefab
    [SerializeField] private Transform enemyTwo;            //Second enemy prefab

    [SerializeField] private float cutSceneTimer;           //Timer that selects when enemies start moving
    [SerializeField] private float movementSpeed;           //Enemy movement speed

    private void Awake()
    {
        Assert.IsNotNull(cutScenePanel);
    }

    private void Start()
    {
        cutScenePanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))                                                                                   //Check if trigger Collided with player
        {
            cutSceneTimer = Time.deltaTime;                                                                                         //starts the timer to spawn enemies

            Instantiate(enemyOne, spawnerOne.transform.position, Quaternion.identity);                                              //Spawns enemy one
            Instantiate(enemyTwo, spawnerTwo.transform.position, Quaternion.identity);                                              //Spawns Enemy two

            if (cutSceneTimer >= 2)                                                                                                 //Check if timer is on 2 seconds
            {
                enemyOne.position = Vector3.MoveTowards(transform.position, moveToPositionOne.transform.position, movementSpeed);   //Move enemy one to moveto position
                enemyTwo.position = Vector3.MoveTowards(transform.position, moveToPositionTwo.transform.position, movementSpeed);   //Move enemy two to moveto position
            }
        }
    }
}
