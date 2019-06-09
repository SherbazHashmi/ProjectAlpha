using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timer = 0;

    private Transform movingPlatform;
    private EdgeCollider2D edgeCollider;

    private void Awake()
    {
        movingPlatform = GetComponent<Transform>();
        edgeCollider = GetComponent<EdgeCollider2D>();
    }

    private void Start()
    {        
        edgeCollider.enabled = false;
    }

    void Update ()
    {
        timer += Time.deltaTime;
        MovePlatform();
        DestroyPlatform();
    }

    /// <summary>
    /// Moves the platform from left to right and reactivates the colliders after 2.5 seconds
    /// </summary>
    void MovePlatform()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if (timer >= 2.5f)
        {
            edgeCollider.enabled = true;
        }
    }

    /// <summary>
    /// destroyes gameobject after it reached the other side of the room
    /// </summary>
    void DestroyPlatform()
    {
        if (timer >= 19f)
        {
            Destroy(this.gameObject);
        }
    }
}
