using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheatingIndicators : MonoBehaviour
{
    private float ObjectHP = 100;
    private Collider2D coll2D;

    private void Awake()
    {
        coll2D = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
