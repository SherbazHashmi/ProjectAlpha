using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScirpt : MonoBehaviour
{
    [SerializeField] private GameObject platformDestroy;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, platformDestroy.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.position.x == platformDestroy.transform.position.x)
        {
            Destroy(this.gameObject);
        }
    }
}
