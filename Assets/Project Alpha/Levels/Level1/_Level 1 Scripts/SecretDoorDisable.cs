using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoorDisable : MonoBehaviour
{
    [SerializeField] private Transform secretDoor;
    [SerializeField] private Transform moveToPosition;
    [SerializeField] private float speed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && gameObject.tag != "Breakable")
        {
            secretDoor.transform.position = Vector3.MoveTowards(transform.position, moveToPosition.transform.position, speed * Time.deltaTime);
        }
        else if (other.tag == "Player" && gameObject.tag == "Breakable" && Input.GetKey("Player1_Shoot"))
        {
            Destroy(this.gameObject);
        }
    }
}
