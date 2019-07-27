using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSevenDoorLever : MonoBehaviour
{
    [SerializeField] private GameObject doorObject;             //Creates door Object var
    [SerializeField] private GameObject moveToPosition;         //Creates move to position var
    [SerializeField] private GameObject leverUp;                //Creates Lever up Image var
    [SerializeField] private GameObject leverDown;              //creates lever down Image var
    [SerializeField] private float speed;                       //sets door speed

    private bool doorMove = false;                              //door move bool

    private void Start()
    {
        leverUp.SetActive(true);                                //Sets up image active
        leverDown.SetActive(false);                             //Sets down image active
    }

    private void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        if (doorMove)                                                                                                                                       //checks that door move bool is true
        {
            leverUp.SetActive(false);                                                                                                                       //deactivates up image
            leverDown.SetActive(true);                                                                                                                      //activates down image
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, moveToPosition.transform.position, speed * Time.deltaTime);  //moves door
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player") /*&& Input.GetButton("Use")*/)     //Checks door move condition
        {
            doorMove = true;                                                        //sets doot bool to true so door can move
        }
    }
}
