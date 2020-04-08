using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAbilityController : MonoBehaviour
{
    NPCHandler npcHandler;
   // [SerializeField] float meleeDamage = 20;
    private float critChance = 15;
    private float rng;
    private float meleeDamage;


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
                meleeDamage = WeaponManager.damage;
                // meleeDamage = 20;
                CritStrike();
                npc.Attack(meleeDamage);
                Debug.Log("damage :"+ meleeDamage);
                 
                
            }
        }
    }
    void CritStrike()
    {
        rng = Random.Range(1, 100);
        if(rng <= critChance)
        {
            meleeDamage = meleeDamage * 2;
            Debug.Log("Crit is working");
        }
        else
        {
            
        }
    }
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
