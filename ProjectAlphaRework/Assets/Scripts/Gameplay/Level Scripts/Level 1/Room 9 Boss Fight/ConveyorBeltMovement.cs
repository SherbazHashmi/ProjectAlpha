using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timer = 0;
    [SerializeField] private float destroyTimer;

    private Transform movingPlatform;

    private void Awake()
    {
        movingPlatform = GetComponent<Transform>();
    }

    private void Start()
    {
    }

    void Update()
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
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    /// <summary>
    /// destroyes gameobject after it reached the other side of the room
    /// </summary>
    void DestroyPlatform()
    {
        if (timer >= destroyTimer)
        {
            Destroy(this.gameObject);
        }
    }
}
