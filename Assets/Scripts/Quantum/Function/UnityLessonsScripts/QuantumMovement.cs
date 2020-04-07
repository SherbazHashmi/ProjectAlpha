using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumMovement : QuantumPhysics2D
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;
    public int maxJumps = 2;

    private SpriteRenderer spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded || maxJumps >= 0)
        {
            velocity.y = jumpTakeOffSpeed;
            maxJumps--;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y < 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //anim.SetBool("grounded" grounded);
        //anim.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;

        base.ComputeVelocity();
    }
}
