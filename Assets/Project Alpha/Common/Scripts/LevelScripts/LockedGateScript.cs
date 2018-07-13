using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGateScript : MonoBehaviour
{
    [SerializeField] private Transform doorToOpen;
    [SerializeField] private Transform doorMovePosition;
    [SerializeField] private float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetKey("Player1_Shoot"))
        {
            doorToOpen.position = Vector3.MoveTowards(transform.position, doorMovePosition.position, speed * Time.deltaTime);
        }
    }
}
