using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    //[SerializeField] private GameObject laserObject;
    [SerializeField] private GameObject firePoint;

    private RoomNineHandler roomNineHandler;
    private GameObject laserClone;

    private void Start()
    {
        roomNineHandler = FindObjectOfType<RoomNineHandler>();
    }

    private void Update()
    {
    }

    private void TargetEnemy()
    {
        if (roomNineHandler.laserTargetEnemy)
        {

        }
    }

    private void FollowQuantum()
    {
        if (roomNineHandler.laserTargerQuantum)
        {

        }
    }

    private void ShootLaser()
    {
        //laserClone = Instantiate(laserObject, firePoint.transform.position, Quaternion.identity);
    }
}
