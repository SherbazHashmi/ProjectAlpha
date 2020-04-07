using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class SecretDoorDestroy : MonoBehaviour
{
    [SerializeField] private GameObject hiddenAreaCover;        //Sets Hidden Area Cover
    [SerializeField] private Sprite secretDoor;                 //Sets secret door Varible
    [SerializeField] private Sprite doorSpriteIntact;           //Sets image hit once var
    [SerializeField] private Sprite doorSpriteDamaged;          //sets image hit twice var

    private int hitCount = 3;                                   //sets var that tells how many times a door must be hit           

    private SpriteRenderer spriteRenderer;                      //gets sprite renderer var

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        //gets sprite renderer component

        hiddenAreaCover.SetActive(true);                        //enables hidden area covers
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && coll.gameObject.CompareTag("melee") || coll.gameObject.CompareTag("PlayerProjectile"))      //checks if quantum damaged door
        {
            hitCount--;                                                                                                                         //Subtracts hits to display correct image or destroy

            if (hitCount == 3)                                                                                                                  //Check if hitcount is 3
            {
                spriteRenderer.sprite = secretDoor;                                                                                             //Sets undamaged image
            }
            else if (hitCount == 2)                                                                                                             //checks if hit count is 2
            {
                spriteRenderer.sprite = doorSpriteIntact;                                                                                       //Sets damaged door 1
            }
            else if (hitCount == 1)                                                                                                             //check if hit count is 1
            {
                spriteRenderer.sprite = doorSpriteDamaged;                                                                                      //sets damaged door 2
            }
            else if (hitCount == 0)                                                                                                             //check if hit count is 0
            {
                hiddenAreaCover.SetActive(false);                                                                                               //uncover hidden area
                Destroy(this.gameObject);                                                                                                       //destroy door
            }
        }
    }
}
