using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour
{
    QuantumController quantumController;
    QuantumAbilityController quantumAbilityController;
    Dictionary<KeyCode[], string> movementKeybindings = new Dictionary<KeyCode[], string>
    {
        { new[] { KeyCode.Space }, "QuantumJump" },
        { new[] { KeyCode.LeftArrow, KeyCode.A }, "MoveLeft" },
        { new[] { KeyCode.RightArrow, KeyCode.D }, "MoveRight" },
        { new[] { KeyCode.DownArrow, KeyCode.S }, "QuantumCrouch" },
    };

    Dictionary<KeyCode[], string> abilityKeybindings = new Dictionary<KeyCode[], string>
    {
        { new[] { KeyCode.Q }, "Melee" },
        { new[] { KeyCode.E } , "Interact" }

    };
    Dictionary<string, Dictionary<KeyCode[], string>> keybindings;
    // Start is called before the first frame update
    void Start()
    {
        quantumController = GetComponent<QuantumController>();
        quantumAbilityController = GetComponent<QuantumAbilityController>();
        keybindings = new Dictionary<string, Dictionary<KeyCode[], string>> {
            { "movement", movementKeybindings },
            { "ability",abilityKeybindings }
        };
    }


    // Update is called once  per frame
    void Update()
    {
        StartCoroutine(CheckForMovement());
        StartCoroutine(CheckForAbility());
    }


    IEnumerator CheckForAbility()
    {
        System.Reflection.MethodInfo mi; // Will be used to store method required
        foreach (KeyValuePair<KeyCode[], string> keybind in abilityKeybindings)
        {
            foreach (KeyCode keyCode in keybind.Key)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    mi = quantumAbilityController.GetType().GetMethod(keybind.Value); // Setting Method
                    mi.Invoke(quantumAbilityController, null);
                    yield return new WaitForSeconds(1F); // Waiting to not overwhelm system

                }

                if (Input.GetKeyUp(keyCode))
                {
                    
                }
            }
        }
    }

    // Checks for Input and Responds to It
    IEnumerator CheckForMovement()
    {
        System.Reflection.MethodInfo mi; // Will be used to store method required
        foreach (KeyValuePair<KeyCode[], string> keybind in movementKeybindings)
        {
            foreach (KeyCode keyCode in keybind.Key)
            {
                yield return new WaitForSeconds(0.001F); // Waiting to not overwhelm system
                if (Input.GetKeyDown(keyCode))
                {
                    mi = quantumController.GetType().GetMethod(keybind.Value); // Setting Method
                    mi.Invoke(quantumController, null);
                }

                if (Input.GetKeyUp(keyCode))
                {
                    mi = quantumController.GetType().GetMethod("Stop" + keybind.Value);
                    mi.Invoke(quantumController, null);
                }
            }
        }
    }
}
