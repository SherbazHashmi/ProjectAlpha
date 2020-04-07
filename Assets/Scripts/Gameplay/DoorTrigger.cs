using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject doorObject;
    [SerializeField] private GameObject moveToPosition;
    [SerializeField] private float speed;

    private bool doorMove = false;

    private void Update()
    {
        MoveDoor();
    }

    private void MoveDoor()
    {
        if (doorMove)
        {
            Debug.Log("Quantum Enters Door Trigger(DoorTrigger.cs)");
            doorObject.transform.position = Vector3.MoveTowards(doorObject.transform.position, moveToPosition.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    { 
        if (coll.gameObject.CompareTag("Player"))
        {
            doorMove = true;
        }
    }
}
