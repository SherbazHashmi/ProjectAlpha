using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAnimationControl : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>() as Animator;
    }

    public void QuantumIdle()
    {
        anim.SetBool("isIdle", true);
        anim.SetBool("isWalking", false);
        anim.speed = 1;
    }

    public void QuantumWalking()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", true);
        anim.speed = 1;
    }

    public void QuantumWalkBack()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isWalking", true);
    }
}
