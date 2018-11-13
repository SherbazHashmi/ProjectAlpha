using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject triggerCollider;
    [SerializeField] private GameObject moveToPosition;
    [SerializeField] private float speed;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerCollider.tag == "Player")
        {
            transform.Translate(Vector3.MoveTowards(transform.position, moveToPosition.transform.position, speed * Time.deltaTime));
        }
    }
}
