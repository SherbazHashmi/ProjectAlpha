using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingPlatforms : MonoBehaviour
{
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 botPosition;

    [SerializeField] private float cutSceneTimer;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float secondsToWait = 0f;

    private RoomNineManager roomNineManager;

    private void Awake()
    {
        roomNineManager = GetComponent<RoomNineManager>();
    }
    private void Start()
    {
    }

    private void Update()
    {
        cutSceneTimer += 1 * Time.deltaTime;

        //DamageToQuantum();
        if (cutSceneTimer >= 10f)
        {
            StartCoroutine(MoveUpDown(botPosition));
        }
    }

    IEnumerator MoveUpDown(Vector3 target)
    {
        while (Mathf.Abs((target - transform.localPosition).y) > 20)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * speed * Time.deltaTime;

            yield return null;
        }

        yield return new WaitForSeconds(secondsToWait);

        Vector3 newTarget = target.y == topPosition.y ? botPosition : topPosition;
        StartCoroutine(MoveUpDown(newTarget));
    }

    /*public void DamageToQuantum()
    {
        Logic to damage Quantum here
    }*/
}
