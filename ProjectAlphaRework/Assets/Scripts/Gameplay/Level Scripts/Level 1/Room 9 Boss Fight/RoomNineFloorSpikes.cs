using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomNineFloorSpikes : MonoBehaviour
{
    [SerializeField] private Vector2 topPosition;                           //sets top position
    [SerializeField] private Vector2 botPosition;                           //sets bot position
    [SerializeField] private float speed;/*needs to be set in inspector*/   //sets speed that spikes move

    private RoomNineHandler roomNineHandler;                                //RoomNineHandler.cs

    private void Awake()
    {
        roomNineHandler = FindObjectOfType<RoomNineHandler>();              //finds RoomNineHandler.cs
    }

    private void Update()
    {
        if (roomNineHandler.floorSpikes)                                    //check if floorspike bool is true
        {
            StartCoroutine(Move(botPosition));                              //Starts Move() coroutine
        }
    }

    /// <summary>
    /// Coroutine that makes the Spikes move up and down
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    IEnumerator Move(Vector3 target)
    {

        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)                 //loops position
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;  //Checks position
            transform.localPosition += direction * speed * Time.deltaTime;              //moves to next direction

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? botPosition : topPosition;      //changes position

        StartCoroutine(Move(newTarget));
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            /**************Place Damage and stun Code Here***************/
        }
    }
}
