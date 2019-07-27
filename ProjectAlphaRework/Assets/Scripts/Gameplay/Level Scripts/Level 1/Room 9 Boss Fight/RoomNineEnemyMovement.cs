using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNineEnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform enemyMoveToPosition;
    private float enemyMovementSpeed = 5;

    private RoomNineHandler roomNineHandler;

    private void Start()
    {
        roomNineHandler = FindObjectOfType<RoomNineHandler>();
    }

    private void Update()
    {
        if (roomNineHandler.enemyMove)
        {
            EnemyMove();
        }
    }

    void EnemyMove()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyMoveToPosition.transform.position, enemyMovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            Destroy(gameObject);
        }
    }
}
