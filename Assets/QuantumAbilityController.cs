using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAbilityController : MonoBehaviour
{
    NPCHandler npcHandler;
    QuantumController quantumController;
    private isInteractableIcon isInteractableIcon;
    [SerializeField] float meleeDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        npcHandler = FindObjectOfType<NPCHandler>();
        quantumController = FindObjectOfType<QuantumController>();
        isInteractableIcon = FindObjectOfType<isInteractableIcon>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (NonPlayableCharacter npc in npcHandler.nonPlayableCharacters)
        {
            if (npc.isInRange(this.gameObject.transform.position) && npc.isFriendly && !isInteractableIcon.isShown)
            {
                isInteractableIcon.show();
            }

            if (isInteractableIcon.isShown && !npc.isInRange(transform.position) && npc.isFriendly)
            {
                isInteractableIcon.hide();
            }
        }

    }

    public void Melee()
    {
        foreach(NonPlayableCharacter npc in npcHandler.nonPlayableCharacters)
        {
            bool isFacing = npc.isFacing(quantumController.facingDirection, quantumController.gameObject.transform.position);
            bool isInRange = npc.isInRange(this.gameObject.transform.position);
            if (isFacing && !npc.isFriendly && isInRange)
            {
                npc.Attack(meleeDamage, quantumController.facingDirection);
            }
        }
    }

    public void Interact()
    {
        foreach (NonPlayableCharacter npc in npcHandler.nonPlayableCharacters)
        {
            if (npc.isInRange(this.gameObject.transform.position) && npc.isFriendly)
            {
                npc.interact();
            }
        }
    }
}
