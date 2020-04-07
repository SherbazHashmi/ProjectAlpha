using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAbilityController : MonoBehaviour
{
    NPCHandler npcHandler;
    [SerializeField] float meleeDamage = 20;
    // Start is called before the first frame update
    void Start()
    {
        npcHandler = FindObjectOfType<NPCHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Melee()
    {
        foreach(NonPlayableCharacter npc in npcHandler.nonPlayableCharacters)
        {
            if (npc.isInRange(this.gameObject.transform.position) && !npc.isFriendly)
            {
                npc.Attack(meleeDamage);
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Interact");
    }
}
