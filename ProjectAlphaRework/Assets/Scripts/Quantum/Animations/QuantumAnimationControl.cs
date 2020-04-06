using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAnimationControl : MonoBehaviour
{
    [Header ("Attach Required Scripts")]
    public QuantumController quantumMobileInput;

    private Animator anim;
    private bool quantumIdle;
    private bool quantum_Crouch;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        quantumIdle = true;
        quantum_Crouch = false;
    }

    private void Update()
    {
        QuantumIdleStateCheck();
        PlayRunAnimation();
        QuantumCrouching();
        //QuantumJump();
    }

    /// <summary>
    /// Checks if the isJumping bool in QuantumMobileControl.cs is set to true,
    /// if the bool is true, it sets the jumping bool in the animator controller to true
    /// playing the jump animation. Also disables the function when bool is set to false.
    /// 
    /// CURRENTLY DISABLED DUE TO HAVING ISSUES WITH isGrounded, WILL ENABLE ONCE THE BUG IS RESOLVED
    /// ANIMATION CANT BE RESET UNTIL isGrounded BOOL GOES TO FALSE.
    /// </summary>
    /*private void QuantumJump()
    {
        if (quantumMobileInput.isJumping)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isIdle", false);
        }
        else if (!quantumMobileInput.isJumping)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", false);
        }
    }*/

    /// <summary>
    /// Check the Current state of Quantum and disable or enables the required Idle state
    /// </summary>
    private void QuantumIdleStateCheck()
    {
        if (quantumIdle && !quantum_Crouch)                                                                                         //Check that Quantum idle bool is true and Crouch idle bool is false
        {
            anim.SetBool("isIdle", true);                                                                                           //Sets Animator state to Idle animtion
            anim.SetBool("isCrouching", false);                                                                                     //Disable Idle Crouch State in Animator
        }
        else if (!quantumIdle && !quantum_Crouch)                                                                                   //Checks that quantum idle bool is false and that crouch bool is false
        {
            anim.SetBool("isIdle", false);                                                                                          //Disable animator Idle state
            anim.SetBool("isCrouching", false);                                                                                     //Disbale animator Crouch idle state
        }
        else if (!quantumIdle && quantum_Crouch)                                                                                    //Check if Quantum Idle bool is set to false and quantum crouch bool is set to true
        {

            anim.SetBool("isIdle", false);                                                                                          //Disables Idle animations state in Animator
            anim.SetBool("isCrouching", true);                                                                                      //Sets isCrouching bool to true in animator, playing the crouch idle animation
        }
    }

    /// <summary>
    /// Sets the Crouch state true or false, and updating the animator state according
    /// </summary>
    private void QuantumCrouching()
    {
        if (quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight && !quantumMobileInput.moveLeft)                      //Chacks if quantum crouch but is not moving
        {
            anim.SetBool("isCrouching", true);                                                                                      //plays the crouch animation
            quantumIdle = false;                                                                                                    //sets Idle(standing up) bool to false
            quantum_Crouch = true;                                                                                                  //sets the crouch bool to true
        }

        if (!quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight && !quantumMobileInput.moveLeft)                     //Checks if quantum does not move or crouch
        {
            anim.SetBool("isCrouching", false);                                                                                     //stops the crouch animation
            quantumIdle = true;                                                                                                     //sets Idle(standing up) bool to true
            quantum_Crouch = false;                                                                                                 //sets the crouch bool to true
        }
    }

    /// <summary>
    /// Check if quantum is in upright or crouched position and plays required animation state
    /// ie. if he is standing the runnign animation will play, but if he is crouching, the crouch 
    /// walking animation will play
    /// </summary>
    void PlayRunAnimation()
    {
        if (quantumMobileInput.moveRight && !quantumMobileInput.quantumCrouch && !quantumMobileInput.moveLeft)                      //Check if Quantum is moving right and NOT Crouching and NOT moving Left
        {
            anim.SetBool("isRunning", true);                                                                                        //Sets the animation bool to true, playing the running animation
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (quantumMobileInput.moveRight && quantumMobileInput.quantumCrouch && !quantumMobileInput.moveLeft)                  //Check if Quantum is moving right and crouching and NOT Crouching and NOT moving Left
        {
            anim.SetBool("isCrouchWalking", true);                                                                                  //Sets crouch walking bool to true, playing the crouch walking animations
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method 
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (!quantumMobileInput.moveRight && !quantumMobileInput.quantumCrouch && !quantumMobileInput.moveLeft)                //Check that Quantum is not moving, and also not Crouching and NOT Crouching and NOT moving Left
        {
            anim.SetBool("isRunning", false);                                                                                       //Sets the isRunnign Bool to false, setting aniamtor parameters back to idle
            quantumIdle = true;                                                                                                     //Sets Idle bool to true for state check Method
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (!quantumMobileInput.moveRight && quantumMobileInput.quantumCrouch && !quantumMobileInput.moveLeft)                 //Checks if Quantum is NOT moving and that he IS Crouching and NOT Crouching and NOT moving Left
        {
            anim.SetBool("isCrouchWalking", false);                                                                                 //Sets the IsCrouchWalking Bool to false, setting aniamtor parameters back to idle
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method
            quantum_Crouch = true;                                                                                                  //Sets Crouch idle bool to true for state check Method
        }

        if (quantumMobileInput.moveLeft && !quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight)                      //Check if Quantum is moving Left and NOT Crouching and NOT Crouching and NOT moving right
        {
            anim.SetBool("isRunning", true);                                                                                        //Sets the animation bool to true, playing the running animation
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (quantumMobileInput.moveLeft && quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight)                  //Check if Quantum is moving Left and crouching and NOT Crouching and NOT moving right
        {
            anim.SetBool("isCrouchWalking", true);                                                                                  //Sets crouch walking bool to true, playing the crouch walking animations
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method 
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (!quantumMobileInput.moveLeft && !quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight)                //Check that Quantum is not moving, and also not Crouching and NOT Crouching and NOT moving right
        {
            anim.SetBool("isRunning", false);                                                                                       //Sets the isRunning Bool to false, setting aniamtor parameters back to idle
            quantumIdle = true;                                                                                                     //Sets Idle bool to true for state check Method
            quantum_Crouch = false;                                                                                                 //Sets Crouch idle bool to false for state check Method
        }
        else if (!quantumMobileInput.moveLeft && quantumMobileInput.quantumCrouch && !quantumMobileInput.moveRight)                 //Checks if Quantum is NOT moving and that he IS Crouching and NOT Crouching and NOT moving right
        {
            anim.SetBool("isCrouchWalking", false);                                                                                 //Sets the IsCrouchWalking Bool to false, setting aniamtor parameters back to idle
            quantumIdle = false;                                                                                                    //Sets Idle bool to false for state check Method
            quantum_Crouch = true;                                                                                                  //Sets Crouch idle bool to true for state check Method
        }
    }
}
