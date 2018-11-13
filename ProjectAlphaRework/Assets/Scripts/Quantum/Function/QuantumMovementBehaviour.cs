using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumMovementBehaviour : MonoBehaviour
{
    [Header ("Movement Variables")]
    public float movementSpeed = 15f;
    public float sprintMultipleir = 2f;

    [Header("Jump Variables")]
    public int maxJumps = 2;
    public float jumpForce = 20f;
    public float doubleJumpVelocity = 10f;
    public float jetPackTimer = 3f;

    private InputBindings inputBindings;
    private Rigidbody2D rb2d;
    private Vector2 currentPosition;
    private Animator anim;

    private bool isMoving;
    private bool isGrounded;

    private void Awake()
    {
        inputBindings = GetComponent<InputBindings>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        isMoving = false;
        //isGrounded = true;
        currentPosition = Vector2.zero;
    }

    private void Update()
    {
        Movement();
        //QuantumJump();

        if (!isMoving)
        {
            anim.SetBool("isIdle", true);
        }
    }

    /*private void QuantumJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.D))
        {
            maxJumps--;

            if (maxJumps > 0 && isGrounded)
            {
                rb2d.velocity = new Vector2(movementSpeed, jumpForce);
                if (maxJumps <= 0)
                {
                    isGrounded = false;
                }
            }

            if (isGrounded)
            {
                maxJumps = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKeyDown(KeyCode.A))
        {
            maxJumps--;

            if (maxJumps > 0 && isGrounded)
            {
                rb2d.velocity = new Vector2(-movementSpeed, jumpForce);
                if (maxJumps <= 0)
                {
                    isGrounded = false;
                }
            }

            if (isGrounded)
            {
                maxJumps = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            maxJumps--;

            if (maxJumps > 0 && isGrounded)
            {
                rb2d.velocity = new Vector2(0f, jumpForce);

                if (isGrounded && Input.GetKeyDown(KeyCode.Space) && maxJumps > 0)
                {
                    maxJumps--;
                    rb2d.velocity = new Vector2(0f, jumpForce);
                }

                if (maxJumps <= 0)
                {
                    isGrounded = false;
                }
            }

            if (isGrounded && maxJumps <= 0)
            {
                maxJumps = 2;
                Debug.Log("Quantum is grounded");
            }
        }
    }*/

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2d.velocity = new Vector2(movementSpeed, 0f);
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
            isMoving = true;

            /*if (isMoving && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                rb2d.velocity = new Vector2(movementSpeed * sprintMultipleir, 0f);
            }*/
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            isMoving = false;
            anim.SetBool("isRunning", false);
        }

        /*if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-movementSpeed, 0f);
            isMoving = true;

            if (isMoving)
            {
            }

            if (isMoving && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                rb2d.velocity = new Vector2(-movementSpeed * sprintMultipleir, 0f);
            }
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            isMoving = false;
        }*/
    }
}
