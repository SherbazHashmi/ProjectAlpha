using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEightToNineTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
