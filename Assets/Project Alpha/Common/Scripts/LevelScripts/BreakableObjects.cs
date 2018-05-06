using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (gameObject.tag == "Player" && gameObject.tag == "Breakable" && Input.GetKey("Player1_Shoot"))
        {
            Destroy(this.gameObject);
        }
    }
}
