using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;                 //platform speed
    [SerializeField] private float timer = 0;                   //timer that adds up to tiem that platform needs to be destroyed
    [SerializeField] private float destroyTimer;                //Time to destroy gameObject

    private Transform movingPlatform;                           //Makes a var for the object transform
    private RoomNineHandler roomNineHandler;                    //RoomNinehandler.cs

    private void Awake()
    {
        movingPlatform = GetComponent<Transform>();             //Gets Object Transform
        roomNineHandler = FindObjectOfType<RoomNineHandler>();  //Finds RoomNinehandler.cs
    }

    private void Start()
    {
    }

    void Update()
    {
        if (roomNineHandler.startConveyor)
        {
            timer += Time.deltaTime;        //Sets timer to increment 1 each second
        }

        MovePlatform();
        DestroyPlatform();
    }

    /// <summary>
    /// Moves the platform from left to right and reactivates the colliders after 2.5 seconds
    /// </summary>
    void MovePlatform()
    {
        if (roomNineHandler.startConveyor)                                  //Check that belt can start moving
        {
            transform.Translate(Vector3.up * -speed * Time.deltaTime);      //moves belt 
        }
    }

    /// <summary>
    /// destroyes gameobject after it reached the other side of the room
    /// </summary>
    void DestroyPlatform()
    {
        if (timer >= destroyTimer)      //checks if timer reaches destroy timer
        {
            Destroy(this.gameObject);   //Destroy belt
        }
    }
}
