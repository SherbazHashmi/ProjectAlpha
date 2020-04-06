using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNineDoorMovement : MonoBehaviour
{
    [Header ("Door Objects")]
    public GameObject doorObject;               //Sets door Var
    public GameObject doorMoveToPosition;       //Sets door open position var
    public GameObject doorMoveBackPosition;     //sets door closed position var

    private float doorSpeed = 5;                //sets door speed
    private RoomNineHandler roomNineHandler;    //RoomNinehandler.cs

    private void Start()
    {
        roomNineHandler = FindObjectOfType<RoomNineHandler>();  //Finds RoomNinehandler.cs
    }

    private void Update()
    {
        if (roomNineHandler.leftDoorMovement == true)         //Check of Coroutine reached door movement
        {
            MoveDoorUp();                                     //moves door up
        }
        else if (roomNineHandler.leftDoorMovement == false)   //Check of coroutine reached doot down movement
        {
            MoveDoorDown();                                   //moves door down
        }
    }

    public void MoveDoorUp()
    {
        doorObject.transform.position = Vector3.MoveTowards(transform.position, doorMoveToPosition.transform.position, doorSpeed * Time.deltaTime);     //Moves doot up
    }

    public void MoveDoorDown()
    {
        doorObject.transform.position = Vector3.MoveTowards(transform.position, doorMoveBackPosition.transform.position, doorSpeed * Time.deltaTime);   //moves door down
    }
}
