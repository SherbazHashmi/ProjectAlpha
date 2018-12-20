using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumMobileInput : MonoBehaviour
{
    [Header ("Movement Vars")]
    public float movementSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float jumpForce = 5f;

    [HideInInspector] public bool moveLeft;
    [HideInInspector] public bool moveRight;
    [HideInInspector] public bool quantumJump;
    [HideInInspector] public bool quantumCrouch;
    [HideInInspector] public bool isJumping;

    private int moveDirection = 0;

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
        quantumCrouch = false;
        isJumping = false;
    }

    /// <summary>
    /// All required Methods are called to play when required
    /// </summary>
    private void Update()
    {
        QuantumDirectionalMovement();
        QuantumJump();

        cameraToFollow.transform.position = new Vector3(gameObject.transform.position.x, 0, -10);
    }

    /// <summary>
    /// Uses Rigibody's Impusle mode to push Quantum up on the Y axis to jump
    /// *******PS: Still need to figure out how to set a isGrounded bool, the 
    /// animation components are nested in a Rig object, and the rig is nested 
    /// in a Moving object, thus making it a bit more complicated to do a isGrounded
    /// check.(Leave this tect here until i can get the isGrounded fixed)*************
    /// </summary>
    private void QuantumJump()
    {
        if (quantumJump)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
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
            if (moveDirection >= 1)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            }
        }

        if (!moveRight && moveLeft)
        {
            if (moveDirection <= -1)
            {
                transform.Translate(Vector2.right * movementSpeed * Time.deltaTime); //The reason move left is also set to Vector2.right is because the image flips, so the axis are then turned around on x, so right is left and left is right when flipped
            }
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
        moveDirection = 1;
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
        moveDirection = 0;
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
        moveDirection = -1;
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
        moveDirection = 0;
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
        if (moveDirection >= 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveDirection <= -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
