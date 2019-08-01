using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScatter : MonoBehaviour
{
    [Header ("Birds")]
    [SerializeField] private Transform birdOne;
    [SerializeField] private Transform birdTwo;
    [SerializeField] private float birdMovementSpeed;

    [Header("Move To Positions")]
    [SerializeField] private Transform birdOneMoveToPosition;
    [SerializeField] private Transform birdTwoMoveToPosition;

    private BirdAnimation birdAnimation;

    private void Start()
    {
        birdAnimation = FindObjectOfType<BirdAnimation>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            birdOne.position = Vector3.MoveTowards(birdOne.position, birdOneMoveToPosition.position, birdMovementSpeed * Time.deltaTime);
            birdTwo.position = Vector3.MoveTowards(birdTwo.position, birdTwoMoveToPosition.position, birdMovementSpeed * Time.deltaTime);

            birdAnimation.birdAnimate = true;
        }
    }
}
