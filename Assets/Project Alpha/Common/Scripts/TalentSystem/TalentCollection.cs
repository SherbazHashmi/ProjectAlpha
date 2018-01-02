using System;
using UnityEngine;
using System.Collections.Generic;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection
    {
        private Dictionary<Weapon, bool> talents { get; set; }

        /// Datatype To Store Talents. 
        /// I hope they have it hashed in C#, if not we will have to implement a new datatype.
        /// Talents (CombatAbility, isActive)
        /// Add all abilities to here.


        public Dictionary<Weapon, bool> getTalents()
        {
            return talents;
        }
      
        /// <summary>
        /// Initialises Talents
        /// </summary>
        
        public void initTalents () {
			talents = new Dictionary<Weapon, bool>();
            ProjectileWeapon pelletGunDefaultWeak = new PelletGunDefaultWeak();
			talents.Add(pelletGunDefaultWeak, false);
		}
        
        
        /// <summary>
        /// Activates Talents, returns true if talent activation was successful, false if it is not. 
        /// </summary>        
        /// <param name="talentToActivate"></param>
        /// <returns>Was Talent Activation Successful</returns>

        public bool activateTalent (Weapon talentToActivate) {
            bool isActiveInDictionary;
            talents.TryGetValue(talentToActivate, out isActiveInDictionary);
            if (isActiveInDictionary == false) {
                Weapon desiredCombatAbility = talentToActivate;
                talents.Remove(desiredCombatAbility);
                talents.Add(desiredCombatAbility,true);
                // Dealing With JSON     

                return true;

            }

            return false;
        }
        
        /// <summary>
        /// Deactivates talents, returns true if talent deactivation was successful, false if it is not.
        /// </summary>
        /// <param name="talentToDeactivate"></param>
        /// <returns>Was Talent Deactivation Successful</returns>

        public bool deactivateTalent (Weapon talentToDeactivate){
			bool isActiveInDictionary;
            talents.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            if (isActiveInDictionary == true) {
                talents[talentToDeactivate] = false;
                
                
                return true;
            } 
            return false;
        }

        /// <summary>
        /// Writes talents from talent dictionary, to object above. 
        /// </summary>
        
        public void writeTalents()
        {
            
        }

        /// <summary>
        /// Refreshes talents of object above by reading the binary file. 
        /// </summary>
        
        public void refreshTalents()
        {
            
        }
        /// <summary>
        /// Converts Class Dictionary of Weapon and Boolean to Dictionary of String and Boolean. 
        /// </summary>
        /// <returns>Dictionary of String, Boolean which the binary file will recognise </returns>
    
        public Dictionary<String, bool> toStringDictionary () 
        {
            Dictionary<String, bool> stringOutput = new Dictionary<string, bool>();

            foreach (KeyValuePair<Weapon,bool> entry in talents)    
                
            {
                stringOutput.Add(entry.Key.weaponName,entry.Value);
            }

            return stringOutput;
        }


      
        
    }
}
