using System;
using UnityEngine;
using System.Collections.Generic;
using MoreMountains.CorgiEngine.Pellet_Gun;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection
    {
        /// Initial Implementation of Storing Talents.

        public Dictionary <Weapon.TypeOfWeapon, Dictionary <String,Dictionary<Weapon, bool>>> Talents { get; set; }

        public GameObject WeaponsObject { get; set; }
        private bool _isInit = false;
        
        ///<summary>
        /// Gets Talents Based on TypeOfWeapon given, for instance, if PelletGun is the type of weapon
        /// input, it will return dictionary of all pellet gun talents. 
        /// </summary>
        
        public Dictionary<Weapon, bool> getTalents(Weapon.TypeOfWeapon weaponType, String branch)
        {
            if (branch == null || Talents[weaponType] == null || Talents[weaponType][branch] == null) return null;
            
            Dictionary<String, Dictionary<Weapon, bool>> weaponsTypeFiltered;
            Talents.TryGetValue(weaponType, out weaponsTypeFiltered);

            if (weaponsTypeFiltered == null) return null;
            
            Dictionary<Weapon, bool> weaponsBranchFiltered;
            weaponsTypeFiltered.TryGetValue(branch, out weaponsBranchFiltered);
            return weaponsBranchFiltered;
        }

      

        public string GetTalentsContainer()
        {
            return "Talents :"+ Talents+"is initialised : "+_isInit;
        }
      
    
        /// <summary>
        /// Activates Talents, returns true if talent activation was successful, false if it is not. 
        /// </summary>        
        /// <param name="talentToActivate"></param>
        /// <returns>Was Talent Activation Successful</returns>

        public bool activateTalent (Weapon talentToActivate) {
            bool isActiveInDictionary;
            Dictionary<Weapon, bool> branch = Talents[talentToActivate.WeaponType][talentToActivate.Branch];
            branch.TryGetValue(talentToActivate, out isActiveInDictionary);
            if (isActiveInDictionary == false) {
                Weapon desiredCombatAbility = talentToActivate;
                branch.Remove(desiredCombatAbility);
                branch.Add(desiredCombatAbility,true);
                
                // Finding Object
                
                // TODO : Update with final character object name

                GameObject characterGameObject =  GameObject.Find("Character 1");

                CharacterHandleWeapon characterHandleWeapon =  characterGameObject.GetComponent<CharacterHandleWeapon>();
                
                if(characterHandleWeapon.CurrentWeapon.WeaponType == desiredCombatAbility.WeaponType && characterHandleWeapon.CurrentWeapon.AttackType == desiredCombatAbility.AttackType)
                    characterHandleWeapon.ChangeWeapon(desiredCombatAbility);
                
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
            Dictionary<Weapon, bool> branch = Talents[talentToDeactivate.WeaponType][talentToDeactivate.Branch];
            branch.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            
            branch.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            if (isActiveInDictionary) {
                branch[talentToDeactivate] = false;
                return true;
            } 
            return false;
        }
        
    }
}
