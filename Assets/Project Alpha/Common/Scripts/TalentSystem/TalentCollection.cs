using System;
using UnityEngine;
using System.Collections.Generic;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection
    {
        /// Initial Implementation of Storing Talents.

        private Dictionary <Weapon.TypeOfWeapon, Dictionary <String,Dictionary<Weapon, bool>>> talents { get; set; }
        
        ///<summary>
        /// Gets Talents Based on TypeOfWeapon given, for instance, if PelletGun is the type of weapon
        /// input, it will return dictionary of all pellet gun talents. 
        /// </summary>
        
        public Dictionary<Weapon, bool> getTalents(Weapon.TypeOfWeapon weaponType, String branch)
        {
            if (branch == null || talents[weaponType] == null || talents[weaponType][branch] == null) return null;
            
            Dictionary<String, Dictionary<Weapon, bool>> weaponsTypeFiltered;
            talents.TryGetValue(weaponType, out weaponsTypeFiltered);

            if (weaponsTypeFiltered == null) return null;
            
            Dictionary<Weapon, bool> weaponsBranchFiltered;
            weaponsTypeFiltered.TryGetValue(branch, out weaponsBranchFiltered);
            
            return weaponsBranchFiltered;
        }
      
        /// <summary>
        /// Initialises Talents
        /// Should Be Done Within Loading Scene
        /// </summary>
        
        public void initTalents () {
            
            // Adding Types To Talents
            
            // Instantiating Type of Weapon 
            
            Dictionary<String, Dictionary<Weapon, bool>> pelletGuns = new Dictionary<string, Dictionary<Weapon, bool>>();
            
            // Instantiating Weapon Branch
            
            Dictionary<Weapon, bool> pelletGunDefault = new Dictionary<Weapon, bool>();
            
            // Adding Weapon Scripts to Branch to Later Be Activated or Deactivated. 
            
            // NOTE : For Testing Purposes, The Pellet Gun Default Weak Weapon Will Be Added To The Pellet Gun Collection Five Times.
            pelletGunDefault.Add(new PelletGunDefaultWeak(), false);
            pelletGunDefault.Add(new PelletGunDefaultWeak(), false);
            pelletGunDefault.Add(new PelletGunDefaultWeak(), false);
            pelletGunDefault.Add(new PelletGunDefaultWeak(), false);
            pelletGunDefault.Add(new PelletGunDefaultWeak(), false);
            
            // Adding Branch To Weapon Type 
            
            pelletGuns.Add("Default", pelletGunDefault);
            
            // Adding Weapon Type To Talents 
            
            talents.Add(Weapon.TypeOfWeapon.PelletGun, pelletGuns);
            
            
            // Rocket Launcher
            
            Dictionary<String, Dictionary<Weapon, bool>> rocketLaunchers = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> rocketLauncherDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Rocket Launcher Abilities When Created
            
            
            talents.Add(Weapon.TypeOfWeapon.RocketLauncher, rocketLaunchers);
            
            // Saw Dropper
            
            Dictionary<String, Dictionary<Weapon, bool>> sawDroppers = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> SawDroppperDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Saw Dropper Abilities When Created
            
            talents.Add(Weapon.TypeOfWeapon.SawDropper, sawDroppers);

            // Shotgun
            Dictionary<String, Dictionary<Weapon, bool>> shotGuns = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> shotGunDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Shot Gun Abilities When Created
            
            talents.Add(Weapon.TypeOfWeapon.Shotgun, shotGuns);
            
            
            // Unarmed
            
            Dictionary<String, Dictionary<Weapon, bool>> unarmedAttacks = new Dictionary<string, Dictionary<Weapon, bool>>();
            Dictionary<Weapon, bool> unaramedDefault = new Dictionary<Weapon, bool>();
            
            // TODO : Add Unarmed Abilities When Created
            
            talents.Add(Weapon.TypeOfWeapon.Unarmed,unarmedAttacks);
   	
		}
        
        
        /// <summary>
        /// Activates Talents, returns true if talent activation was successful, false if it is not. 
        /// </summary>        
        /// <param name="talentToActivate"></param>
        /// <returns>Was Talent Activation Successful</returns>

        public bool activateTalent (Weapon talentToActivate) {
            bool isActiveInDictionary;
            Dictionary<Weapon, bool> branch = talents[talentToActivate.WeaponType][talentToActivate.Branch];
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
            Dictionary<Weapon, bool> branch = talents[talentToDeactivate.WeaponType][talentToDeactivate.Branch];
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
