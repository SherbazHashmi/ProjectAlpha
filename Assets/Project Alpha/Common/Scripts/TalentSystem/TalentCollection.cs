using System;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace MoreMountains.CorgiEngine
{
    public class TalentCollection
    {
        private Dictionary<Weapon, bool> _talents { get; set; }
        private CharacterHandleWeapon _weaponHandler { get; set; }
         
        
        /// Datatype To Store Talents. 
        /// I hope they have it hashed in C#, if not we will have to implement a new datatype.
        /// Talents (CombatAbility, isActive)
        /// Add all abilities to here.

        
        
        /// <summary>
        /// Initialises Talents
        /// </summary>
        
        public void InitTalentCollection () {
			_talents = new Dictionary<Weapon, bool>();
            ProjectileWeapon pelletGunDefaultWeak = new PelletGunDefaultWeak();
			_talents.Add(pelletGunDefaultWeak, false);
		}

        /// <summary>
        ///  Sets Up Reference To Weapon Handler Object.
        /// </summary>
         
        public void InitWeaponHandler()
        {
            
            GameObject character = GameObject.Find("Character 1");

            if (character == null)
            {
                throw new NullReferenceException("While Initialising Weapon Handler, Character 1 Can Not Be Found!");
            }
            
            _weaponHandler = character.GetComponent<CharacterHandleWeapon>();

        }
        
        
        /// <summary>
        /// Changes the weapon the character has equipped. Utilised in swapping weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="NullReferenceException"></exception>

        private void ChangeWeapon(Weapon weapon)
        {
            if (_weaponHandler == null)
            {
                throw new NullReferenceException("Weapon Handler Was Null During Change Weapon Function! Have you initialised the weapon handler?");
            }

            if (_weaponHandler.CurrentWeapon == null)
            {
                throw new NullReferenceException("Current Weapon Was Null During Change Weapon Function! Is therean initial weapon in place?");
            } 

            _weaponHandler.ChangeWeapon(weapon);
            
        }

        public Dictionary<Weapon, bool> GetTalents()
        {
            return _talents;
        }
        
        /// <summary>
        /// Activates Talents, returns true if talent activation was successful, false if it is not. 
        /// </summary>        
        /// <param name="weapon"></param>
        /// <returns>Was Talent Activation Successful</returns>

        public bool ActivateTalent (Weapon weapon) {
            bool isActiveInDictionary;
            
            _talents.TryGetValue(weapon, out isActiveInDictionary);
            
            if (isActiveInDictionary == false) {
                
                // Handling Talent Collection 
                Weapon desiredCombatAbility = weapon;
                _talents.Remove(desiredCombatAbility);
                _talents.Add(desiredCombatAbility,true);
                
                // Changing Weapon Within Weapon Handler If The Type Of Weapon Is Same As Currently Equipped

                if (_weaponHandler = null)
                {
                    InitWeaponHandler();
                }
                if (_weaponHandler.CurrentWeapon.WeaponType == weapon.WeaponType)
                {
                    ChangeWeapon(weapon);
                }
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Deactivates talents, returns true if talent deactivation was successful, false if it is not.
        /// </summary>
        /// <param name="talentToDeactivate"></param>
        /// <returns>Was Talent Deactivation Successful</returns>

        public bool DeactivateTalent (Weapon talentToDeactivate){
			bool isActiveInDictionary;
            _talents.TryGetValue(talentToDeactivate, out isActiveInDictionary);
            if (isActiveInDictionary) {
                _talents[talentToDeactivate] = false;

                if (_weaponHandler == null)
                {
                    throw new NullReferenceException("Weapon Handler is returning null in talent deactivation.");
                }
                _weaponHandler.ChangeWeapon(null);
                return true;
            } 
            return false;
        }

        
        /// <summary>
        /// Converts Class Dictionary of Weapon and Boolean to Dictionary of String and Boolean. 
        /// </summary>
        /// <returns>Dictionary of String, Boolean which the binary file will recognise </returns>
    
        public Dictionary<String, bool> ToStringDictionary () 
        {
            Dictionary<String, bool> stringOutput = new Dictionary<string, bool>();

            foreach (KeyValuePair<Weapon,bool> entry in _talents)    
                
            {
                stringOutput.Add(entry.Key.weaponName,entry.Value);
            }

            return stringOutput;
        }

    }
}
