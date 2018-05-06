using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableColliders : MonoBehaviour
{
    private RoomNineManager roomNineManager;
    public GameObject layerObject;

    private void Awake()
    {
        roomNineManager = GetComponent<RoomNineManager>();
    }

    void ReactivateColliders()
    {
        if (roomNineManager.cutSceneTimer >= 5f)
        {
            this.layerObject.layer = LayerMask.NameToLayer("Platforms");
        }
    }
}
