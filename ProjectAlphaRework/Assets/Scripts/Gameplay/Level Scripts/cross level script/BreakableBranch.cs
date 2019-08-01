using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBranch : MonoBehaviour
{
    private float timer;
    private bool timerStart = false;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (timerStart)
        {
            timer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            timerStart = true;

            if (timer >= 3f)
            {
                rb2d.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }
}
