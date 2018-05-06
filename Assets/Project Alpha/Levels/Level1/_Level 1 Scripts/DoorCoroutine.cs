using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCoroutine : MonoBehaviour
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 botPosition;
    [SerializeField] private float speed = 5f;

    private void Start()
    {
        StartCoroutine(MoveUpDown(botPosition));
    }

    IEnumerator MoveUpDown(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 20)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * speed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        Vector3 newTarget = target.y == topPosition.y ? botPosition : topPosition;
        StartCoroutine(MoveUpDown(newTarget));
    }
}
