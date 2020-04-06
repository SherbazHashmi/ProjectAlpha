using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyboardInput : MonoBehaviour
{
    QuantumController quantumController;
    // Start is called before the first frame update
    void Start()
    {
        quantumController = this.gameObject.GetComponent<QuantumController>();
    }

    Dictionary<KeyCode[], string> keybindings = new Dictionary<KeyCode[], string>
    {
        { new[] { KeyCode.Space }, "QuantumJump" },
        { new[] { KeyCode.LeftArrow, KeyCode.A }, "MoveLeft" },
        { new[] { KeyCode.RightArrow, KeyCode.D }, "MoveRight" },
        { new[] { KeyCode.DownArrow, KeyCode.S }, "QuantumCrouch" },
    };

    // Update is called once  per frame
    void Update()
    {
        StartCoroutine(CheckForInput());
    }


    // Checks for Input and Responds to It
    IEnumerator CheckForInput()
    {
        System.Reflection.MethodInfo mi; // Will be used to store method required
        foreach (KeyValuePair<KeyCode[], string> keybind in keybindings)
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
