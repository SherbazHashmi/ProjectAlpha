
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    InteractableObject[] interactableObjects;
    int[] numbers;
    bool isTogged = false;
    InteractableObject currentObject;
    double playerPos;
    double objectPos;

    // Start is called before the first frame update
    void Start()
    {
        // Getting All Interactable Game Objects
        interactableObjects = Object.FindObjectsOfType<InteractableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (InteractableObject interactableObject in interactableObjects)
        {
            // Position of Player and Currently Selected Object Updated 
            playerPos = transform.position.x;
            objectPos = interactableObject.gameObject.transform.position.x;

            // Only Enter if Selected Object is What We're Currently Looking At.
            if ((currentObject == null || currentObject == interactableObject))
            {
                // Check if player is in range of object. 
                if (objectPos - 1.3 < playerPos && objectPos + 1.3 > playerPos)
                {
                    // If it's not already toggled toggle action
                    if (!isTogged)
                    {
                        interactableObject.action();
                        isTogged = true;
                        currentObject = interactableObject;
                    }
                }
                else // If player is out of range
                {
                    if (isTogged) // If it's toggled close the action
                    {
                        interactableObject.close();
                        isTogged = false;
                        currentObject = null; // Reset Current Object As We're Not Targetting it Anymore
                    }
                }
            }
                
        }
        
    }
}
