using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class SecretDoorDestroy : MonoBehaviour
{
    [SerializeField] private GameObject secretDoor;
    [SerializeField] private GameObject hiddenAreaCover;
    [SerializeField] private Sprite doorSpriteIntact;
    [SerializeField] private Sprite doorSpriteDamaged;

    private int hitCount = 2;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        /*Assert.IsNotNull(secretDoor);
        Assert.IsNotNull(doorSpriteIntact);
        Assert.IsNotNull(doorSpriteDamaged);
        Assert.IsNotNull(hiddenAreaCover);*/
    }

    private void Start()
    {
        secretDoor.SetActive(true);
        hiddenAreaCover.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && coll.tag == "Mellee" || coll.tag == "PlayerProjectile")
        {
            hitCount--;

            if (hitCount == 2)
            {
                spriteRenderer.sprite = doorSpriteIntact;
            }
            else if (hitCount == 1)
            {
                spriteRenderer.sprite = doorSpriteDamaged;
            }
            else if(hitCount == 0)
            {
                hiddenAreaCover.SetActive(false);
                Destroy(this.gameObject);
            }
        }
    }
}
