using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMovement : MonoBehaviour
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 botPosition;
    [SerializeField] private Vector3 rotTarget;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    void Start()
    {
        StartCoroutine(Move(botPosition));
    }

    IEnumerator Move(Vector3 target)
    {

        while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * speed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? botPosition : topPosition;

        StartCoroutine(Move(newTarget));
        
    }
}
