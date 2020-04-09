using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumAbilityController : MonoBehaviour
{
    NPCHandler npcHandler;
   
    // crit() variables
    private float critChance = 15;
    private float rng;


    //attack range and damage variables
   
    Vector3 quantumPos;
    Vector3 inicialPos;
    private float quantumPosX;
    private float quantumPosY;
    private float quantumPosZ;
    private float meleeRange;
    private float meleeDamage = WeaponManager.damage;

   
    
    

    // Start is called before the first frame update
    void Start()
    {
        quantumPos = this.gameObject.transform.position;
        npcHandler = FindObjectOfType<NPCHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        //updates the range of the weapon based on quantum's current position
        Vector3 currentPos = transform.position;
        quantumPosX = currentPos.x;
        quantumPosY = currentPos.y;
        quantumPosZ = currentPos.z;
        meleeRange = quantumPosX + WeaponManager.range;
        
    }

    public void Melee()
    {
        meleeDamage = WeaponManager.damage;
        //sets quantum's attack range as a Vector3 to be compared with the npc's position
        Vector3 quantumAttack = new Vector3(meleeRange, quantumPosY, quantumPosZ);       
       
        foreach (NonPlayableCharacter npc in npcHandler.nonPlayableCharacters)
        {
            //check if npc is in range and if it isn't friendly
            if (npc.transform.position.x > quantumPos.x && !npc.isFriendly)
            {
                if (npc.transform.position.x < quantumAttack.x && !npc.isFriendly)
                {
                    
                    //crit modifier is calculated before the hit
                    CritStrike();
                    npc.Attack(meleeDamage);
                    Debug.Log("damage :" + meleeDamage);
                    Debug.Log("value returned from position" + this.gameObject.transform.position);

                }
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
            // reminder to add lifesteal mechanic
        }
        else
        {
            meleeDamage = WeaponManager.damage;
        }
    }
    public void Interact()
    {
        Debug.Log("Interact");
    }
}
