using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LevelEnterCutscene : MonoBehaviour
{
    [SerializeField] private GameObject cutScenePanel;
    [SerializeField] private GameObject spawnerOne;
    [SerializeField] private GameObject spawnerTwo;
    [SerializeField] private GameObject moveToPositionOne;
    [SerializeField] private GameObject moveToPositionTwo;
 
    [SerializeField] private Transform enemyOne;
    [SerializeField] private Transform enemyTwo;

    [SerializeField] private float cutSceneTimer;
    [SerializeField] private float movementSpeed;

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
        if (coll.tag == "Player")
        {
            cutSceneTimer = Time.deltaTime;

            Instantiate(enemyOne, spawnerOne.transform.position, Quaternion.identity);
            Instantiate(enemyTwo, spawnerTwo.transform.position, Quaternion.identity);

            if (cutSceneTimer >= 2)
            {
                enemyOne.position = Vector3.MoveTowards(transform.position, moveToPositionOne.transform.position, movementSpeed);
                enemyTwo.position = Vector3.MoveTowards(transform.position, moveToPositionTwo.transform.position, movementSpeed);
            }
        }
    }
}
