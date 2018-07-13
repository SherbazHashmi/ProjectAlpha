using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpening : MonoBehaviour
{
    [SerializeField] private float timer;

    [SerializeField] private Transform rightPosition;
    [SerializeField] private float speed;

    private void Update()
    {
        timer += 1 * Time.deltaTime;

        MoveDoor();
    }

    void MoveDoor()
    {
        if (timer >= 2f)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightPosition.position, speed * Time.deltaTime);
        }        
    }
}
