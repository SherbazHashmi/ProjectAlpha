using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimation : MonoBehaviour
{
    [HideInInspector] public bool birdAnimate = false;

    private Animator anim;

    void BirdAnimated()
    {
        if (birdAnimate)
        {
            anim.Play("BirdFlying");
        }
    }
}
