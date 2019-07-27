using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEightToNineTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))   //check if collision is with player
        {
            Destroy(this.gameObject);               //destroy object
        }
    }
}
