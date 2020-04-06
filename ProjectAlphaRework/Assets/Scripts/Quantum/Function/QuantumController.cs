using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumController : MonoBehaviour
{
    [Header ("Movement Vars")]
    public float movementSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float jumpForce = 5f;
    public Animator animator;
    [HideInInspector] public bool moveLeft;
    [HideInInspector] public bool moveRight;
    [HideInInspector] public bool quantumJump;
    [HideInInspector] public bool quantumCrouch;
    [HideInInspector] public bool isJumping;
    
    private int jumpCounter;
    private bool canJump;
    private float jumpTimer;

    private Rigidbody2D rb2d;
    private bool isGrounded;
    private Vector2 currentPosition;
    private Camera cameraToFollow;

    /// <summary>
    /// Gets the Desired Components thats being used on the Quantum Object
    /// </summary>
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        cameraToFollow = FindObjectOfType<Camera>();
    }

    /// <summary>
    /// Makes sure that all Values for Variables are set correctly at start.
    /// </summary>
    private void Start()
    {
        moveRight = false;
        moveLeft = false;
        quantumJump = false;
        jumpCounter = 0;
        quantumCrouch = false;
        isJumping = false;
    }

    /// <summary>
    /// All required Methods are called to play when required
    /// </summary>
    private void Update()
    {
        QuantumDirectionalMovement();
        animator.SetBool("isMoving", moveRight || moveLeft);
        cameraToFollow.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        incrementTimer();
    }


    private void incrementTimer()
    {
        if(jumpTimer < 30)
        {
            jumpTimer++;
        } else
        {
            jumpTimer = 0;
            canJump = true;
        }

    }

    /// <summary>
    /// Uses Rigibody's Impusle mode to push Quantum up on the Y axis to jump
    /// *******PS: Still need to figure out how to set a isGrounded bool, the 
    /// animation components are nested in a Rig object, and the rig is nested 
    /// in a Moving object, thus making it a bit more complicated to do a isGrounded
    /// check.(Leave this tect here until i can get the isGrounded fixed)*************
    /// </summary>

    public void QuantumJump()
    {
        if (canJump)
        {
            if (jumpCounter < 2)
            {
                rb2d.AddForce(new Vector2(0, 2) * new Vector2(0, jumpForce), ForceMode2D.Impulse);
                jumpCounter++;
            }
            else
            {
                jumpCounter = 0;
            }
            canJump = false;
        }


    }

    /// <summary>
    /// Gets the Move Left or Right bools to Translate the transform of the gameobject
    /// to the direction required for quantum movement
    /// </summary>
    private void QuantumDirectionalMovement()
    {
        if (moveRight && !moveLeft)
        {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }

        if (!moveRight && moveLeft)
        {
           
                transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
    }


    /// <summary>
    /// Sets moveRight Bool to true when the button is touched
    /// MoveRight is to be attached to the button via a event trigger
    /// component added to the button, then set to "Pointer Enter".
    /// Being mobile it will still count as pushing the button down
    /// </summary>
    public void MoveRight()
    {
        moveRight = true;
        FlipAnimation();
    }

    /// <summary>
    /// Sets moveRight Bool to false when the button is touched
    /// StopMoveRight is to be attached to the button via a event trigger
    /// component added to the button, then set to "Pointer Exit".
    /// Being mobile it will still count as pushing the button down
    /// </summary>
    public void StopMoveRight()
    {
        moveRight = false;
    }

    public void StopQuantumJump()
    {

    }

    public void StopQuantumCrouch()
    {

    }

    /// <summary>
    /// Sets moveLeft Bool to true when the button is touched
    /// MoveLeft is to be attached to the button via a event trigger
    /// component added to the button, then set to "Pointer Enter".
    /// Being mobile it will still count as pushing the button down
    /// </summary>
    public void MoveLeft()
    {
        moveLeft = true;
        FlipAnimation();
    }

    /// <summary>
    /// Sets moveLeft Bool to false when the button is touched
    /// StopMoveleft is to be attached to the button via a event trigger
    /// component added to the button, then set to "Pointer Exit".
    /// Being mobile it will still count as pushing the button down
    /// </summary>
    public void StopMoveLeft()
    {
        moveLeft = false;
    }

    /// <summary>
    /// Sets quantumJump and isJumping Bool to true when the button is touched
    /// quantumJump is to be attached to the button via a event trigger
    /// component added to the button, then set to "clicked".
    /// Being mobile it will still count as pushing the button down.
    /// The isJumping variable is to set the Jumping bool to true so that 
    /// the Jumping animation can play
    /// </summary>
    public void Jump()
    {
        quantumJump = true;
        isJumping = true;
    }

    /// <summary>
    /// Sets quantumJump and isJumping Bool to false when the button is touched
    /// quantumJump is to be attached to the button via a event trigger
    /// component added to the button, then set to "Pointer Exit".
    /// Being mobile it will still count as pushing the button down.
    /// The isJumping variable is to set the Jumping bool to false so that 
    /// the Jumping animation can stop
    /// </summary>
    public void SetJumpBoolToFalse()
    {
        quantumJump = false;
        isJumping = false;
    }

    /// <summary>
    /// Sets the quantumCrouch bool to true so that the corresponding animation can 
    /// play, while at the same time setting the buttons to desired state, upright 
    /// and crouched buttons. Remember to attach all buttons correctly in the inspector.
    /// </summary>
    public void QuantumCrouch()
    {
        quantumCrouch = true;
    }

    /// <summary>
    /// Sets the quantumCrouch bool to false so that the corresponding animation can 
    /// play, while at the same time setting the buttons to desired state, upright 
    /// and crouched buttons. Remember to attach all buttons correctly in the inspector.
    /// </summary>
    public void QuantumStopCrouching()
    {
        quantumCrouch = false;
    }

    /// <summary>
    /// Flips the animation to the required direction that Quantum turns to.
    /// </summary>
    public void FlipAnimation()
    {
        if (moveLeft && transform.localScale.x > 0)
        {

            transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), transform.localScale);
        }
        else if (moveRight && transform.localScale.x < 0)
        {
            transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), transform.localScale);
        }
    }
}

