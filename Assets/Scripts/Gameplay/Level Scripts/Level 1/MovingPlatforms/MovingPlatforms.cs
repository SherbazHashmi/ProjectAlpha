using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private float speed = 10f;     //Sets platform movement speed
    [SerializeField] private float timer = 0;       //sets timer to enable collider

    private Transform movingPlatform;               //makes variable platform transform
    private EdgeCollider2D edgeCollider;            //makes variable for edgecollider

    private void Awake()
    {
        movingPlatform = GetComponent<Transform>();         //gets platform transform
        edgeCollider = GetComponent<EdgeCollider2D>();      //gets edge collider
    }

    private void Start()
    {        
        edgeCollider.enabled = false;       //disbales edge collider
    }

    void Update ()
    {
        timer += Time.deltaTime;        //Sets timer to increment 1 per second
        MovePlatform();
        DestroyPlatform();
    }

    /// <summary>
    /// Moves the platform from left to right and reactivates the colliders after 2.5 seconds
    /// </summary>
    void MovePlatform()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);        //moves platform

        if (timer >= 2.5f)                                                  //checks that timer reaches 2.5 seconds
        {
            edgeCollider.enabled = true;                                    //enables edge collider
        }
    }

    /// <summary>
    /// destroyes gameobject after it reached the other side of the room
    /// </summary>
    void DestroyPlatform()
    {
        if (timer >= 19f)                   //checks that timer reaches 19 seconds
        {
            Destroy(this.gameObject);       //destrou Platform
        }
    }
}
