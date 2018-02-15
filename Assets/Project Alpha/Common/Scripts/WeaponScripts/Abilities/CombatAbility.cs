using System;
using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;


namespace MoreMountains.CorgiEngine {
    // FIXME : If you can find a more elegant way to do this tell me. 

	
    /// <summary>
    /// Talent Class denoting the name, ability, whether the talent is active, type of weapon, type of attack to replace, and the level of the talent. 
    /// </summary>


    // TODO : Modify CharacterAbility class to work with talent class by adding TypeOfWeapon and TypeOfAbility parameters. 

    public class RangedCombatAbility : ProjectileWeapon
    {

        public string Name;
        public string UpgradePath;
        public bool IsTalentAbility;
        public int RequiredTalentPoints;
        public TypeOfAttack AttackType { get; set; }
        public TypeOfWeapon WeaponType { get; set; }
	    public bool IsUnlocked;
	    public bool IsActive { get; set; }


	    public RangedCombatAbility()
	    {
		    
	    }
	    
	    
        public RangedCombatAbility (string name, string upgradePath, bool isTalentAbility, int requiredTalentPoints, TypeOfAttack attackType, TypeOfWeapon weaponType) {
            this.Name = name;
            this.IsTalentAbility = isTalentAbility;
            this.UpgradePath = upgradePath;
            this.RequiredTalentPoints = requiredTalentPoints;
            this.AttackType = attackType;
            this.WeaponType = weaponType;
	        this.IsActive = false;

        }



        public string toString () {
            return "name : " + Name + ", upgrade path : " + UpgradePath + ", isActive : " +  ", type of weapon : " + WeaponType + ", type of attack to replace : " + AttackType + ".";
        }

      
    }


    public class MeleeCombatAbility : MeleeWeapon 
    {
		public string Name;
		public string UpgradePath;
		public bool IsTalentAbility;
		public int RequiredTalentPoints;
		public TypeOfAttack AttackType { get; set; }
		public TypeOfWeapon WeaponType { get; set; }
	    public bool IsActive;

		public string toString()
		{
			return "name : " + name + ", upgrade path : " + UpgradePath + ", isActive : " + ", type of weapon : " + WeaponType + ", type of attack to replace : " + AttackType + ".";
		}

	    
	    // Used to instantiate when generating within a subclass. 
	    
	    public MeleeCombatAbility()
	    {
		    
	    }

	    public MeleeCombatAbility(string name, string upgradePath, bool isTalentAbility, int requiredTalentPoints, TypeOfAttack attackType, TypeOfWeapon weaponType, bool isActive)
	    {
		    Name = name;
		    UpgradePath = upgradePath;
		    IsTalentAbility = isTalentAbility;
		    RequiredTalentPoints = requiredTalentPoints;
		    AttackType = attackType;
		    WeaponType = weaponType;
		    IsActive = isActive;
	    }
	    
	    
    }

}
