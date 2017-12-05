using UnityEngine;
using System.Collections;
using MoreMountains.CorgiEngine;


namespace MoreMountains.CorgiEngine {
    
	/// <summary>
	/// Type of Attack This Talent Replaces (As Outlined in Documentation)
	/// Ref : https://docs.google.com/document/d/14MyKsqf8reATkkiQ2IGxU-T1GgR7HDV_C2v7vzJpwIs
	/// </summary>

	public enum TypeOfAttack {
        Weak,
        Strong,
        Ultimate,
        Movement
    }


    /// <summary>
    ///  Type of Weapon That This Talent Applies To
    /// </summary>


    public enum TypeOfWeapon {
        SawDropper,
        RocketLauncher,
        Shotgun,
        PelletGun,
        Unarmed
    }


    /// <summary>
    /// Talent Class denoting the name, ability, whether the talent is active, type of weapon, type of attack to replace, and the level of the talent. 
    /// </summary>


    // TODO : Modify CharacterAbility class to work with talent class by adding TypeOfWeapon and TypeOfAbility parameters. 

    public class CombatAbility : CharacterAbility
    {

        string name;
        string upgradePath;
        bool isTalentAbility;
        CharacterAbility ability;
        int requiredTalentPoints;
        public TypeOfAttack attackType { get; set; }
        public TypeOfWeapon weaponType { get; set; }


        public CombatAbility (string upgradePath, bool isTalentAbility, int requiredTalentPoints, TypeOfAttack attackType, TypeOfWeapon weaponType) {
            this.name = ability.name;
            this.isTalentAbility = isTalentAbility;
            this.upgradePath = upgradePath;
            this.requiredTalentPoints = requiredTalentPoints;
            this.attackType = attackType;
            this.weaponType = weaponType;

        }



        public string toString () {
            return "name : " + name + ", upgrade path : " + upgradePath + ", isActive : " +  ", type of weapon : " + weaponType + ", type of attack to replace : " + attackType + ".";
        }

      
    }

}
